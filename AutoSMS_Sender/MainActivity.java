package com.example.project_zaliczeniowy.sms;

import android.app.Activity;
import android.app.AlarmManager;
import android.app.DatePickerDialog;
import android.app.PendingIntent;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Bundle;

import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.view.View.OnClickListener;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.TimeZone;


public class MainActivity extends Activity implements OnClickListener{

    public static final String LOGFILE = "/data/data/com.example.project_zaliczeniowy.sms/cache/logs.txt";
    public static final String NUMBER = "NUMBER";
    public static final String MESSAGE = "MESSAGE";
    public static final String SAVE = "SAVE_ERROR";

    private static final String CREATE = "CREATE_ERROR";
    private final String TIMEZONE = "Europe/Warsaw";
    private EditText numberText;
    private EditText messageText;
    private Button sendBut;
    private Button clearBut;
    private Button logBut;
    private Button dateBut;
    private Button timeBut;
    private TextView dateView;
    private TextView timeView;
    private int year;
    private int month;
    private int day;
    private int hour;
    private int minute;
    private Calendar cal;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        numberText = (EditText) findViewById(R.id.number);
        messageText = (EditText) findViewById(R.id.message);
        dateView = (TextView) findViewById(R.id.dateField);
        timeView = (TextView) findViewById(R.id.timeField);
        sendBut = (Button) findViewById(R.id.sendBut);
        sendBut.setOnClickListener(this);
        clearBut = (Button) findViewById(R.id.clearBut);
        clearBut.setOnClickListener(this);
        logBut = (Button) findViewById(R.id.logBut);
        logBut.setOnClickListener(this);
        dateBut = (Button) findViewById(R.id.dateBut);
        dateBut.setOnClickListener(this);
        timeBut = (Button) findViewById(R.id.timeBut);
        timeBut.setOnClickListener(this);
        cal = new GregorianCalendar();
        cal.setTimeZone(TimeZone.getTimeZone(TIMEZONE));

        try {
            createLogFile();
        } catch (IOException ex)
        {
            Toast.makeText(this, "Cannot create the log file!", Toast.LENGTH_LONG).show();
            Log.d(CREATE, ex.getMessage().toString());
        }
    }

    @Override
    public void onClick(View v) {

        if (v == dateBut) setDate();
        else if (v == timeBut) setTime();
        else if (v == clearBut) clearForm();
        else if (v == logBut) startActivity(new Intent(this, LogActivity.class));
        else if (v == sendBut) prepareMessage(numberText.getText().toString(), messageText.getText().toString());

    }

    private void createLogFile() throws IOException {

        File file = new File(LOGFILE);
        if (!file.exists())
        {
            FileWriter fw = new FileWriter(file, true);
            fw.close();
        }
    }

    private void setDate() {
        int currYear =  cal.get(GregorianCalendar.YEAR);
        int currMonth = cal.get(GregorianCalendar.MONTH);
        int currDay = cal.get(GregorianCalendar.DAY_OF_MONTH);
        DatePickerDialog dpd = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker dataPick, int tYear,
                                  int tMonth, int tDay) {

                String dateString = tDay + "." + (tMonth+1) + "." + tYear;;
                if (tDay < 10 && (tMonth+1) < 10)
                    dateString = "0" + tDay + ".0" + (tMonth+1) + "." + tYear;
                else if ((tMonth+1) < 10)
                    dateString = tDay + ".0" + (tMonth+1) + "." + tYear;
                else if (tDay < 10)
                    dateString = "0" + tDay + "." + (tMonth+1) + "." + tYear;
                dateView.setText(dateString);
                year = tYear;
                month = tMonth;
                day = tDay;
            }
        }, currYear, currMonth, currDay);
        dpd.show();
    }

    private void setTime() {
        int currHour = cal.get(GregorianCalendar.HOUR_OF_DAY);
        int currMinute = cal.get(GregorianCalendar.MINUTE);
        TimePickerDialog tpd = new TimePickerDialog(this, new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker timePick, int tHour, int tMinute) {

                String timeString = tHour + ":" + tMinute;
                if (tMinute < 10)
                    timeString = tHour + ":0" + tMinute;
                timeView.setText(timeString);
                hour = tHour;
                minute = tMinute;
            }
        }, currHour, currMinute, true);
        tpd.show();
    }

    private void clearForm() {
        numberText.setText("");
        messageText.setText("");
        dateView.setText("");
        timeView.setText("");
    }

    private void setCalendar() {
        cal.set(GregorianCalendar.YEAR, year);
        cal.set(GregorianCalendar.MONTH, month);
        cal.set(GregorianCalendar.DAY_OF_MONTH, day);
        cal.set(GregorianCalendar.HOUR_OF_DAY, hour);
        cal.set(GregorianCalendar.MINUTE, minute);
    }

    private void saveToLogFile(String number, String text) throws IOException {
        final String STATUS = "Non sent";
        File file = new File(LOGFILE);
        FileWriter fw = new FileWriter(file, true);
        StringBuilder builder = new StringBuilder();
        builder.append(number + ";" + text + ";" + STATUS +";Will be sent at" + year + "." + (month+1) + "." + day + ";" + hour + ":" + minute + ";\r\n");
        fw.write(builder.toString());
        fw.flush();
        fw.close();
    }

    private void prepareMessage(String number, String text) {
        Intent alarmIntent = new Intent(this, SmsSender.class);
        alarmIntent.putExtra(NUMBER, number);
        alarmIntent.putExtra(MESSAGE, text);
        PendingIntent pendingIntent = PendingIntent.getBroadcast(this, 0,alarmIntent, PendingIntent.FLAG_ONE_SHOT);
        AlarmManager alarmManager = (AlarmManager) getSystemService(ALARM_SERVICE);
        setCalendar();
        alarmManager.set(AlarmManager.RTC_WAKEUP, cal.getTimeInMillis(), pendingIntent);

        try {
            saveToLogFile(number, text);
            Toast.makeText(this, "The sms has been added to the schedule!", Toast.LENGTH_LONG).show();
        } catch (IOException ex)
        {
            Toast.makeText(this, "Cannot write to the log file!", Toast.LENGTH_LONG).show();
            Log.d(SAVE, ex.getMessage().toString());
        }

    }

}