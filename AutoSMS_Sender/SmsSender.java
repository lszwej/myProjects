package com.example.project_zaliczeniowy.sms;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.telephony.SmsManager;
import android.util.Log;
import android.widget.Toast;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Date;

public class SmsSender extends BroadcastReceiver {

    private final String ARGUMENTS = "BAD_ARGUMENTS";

    @Override
    public void onReceive(Context context, Intent intent) {

        try{
            String number = intent.getStringExtra(MainActivity.NUMBER);
            String text = intent.getStringExtra(MainActivity.MESSAGE);
            sendMessage(context, number, text);

        }  catch (IllegalArgumentException ex) {

           Toast.makeText(context, "The number or message cannot be nulls!", Toast.LENGTH_LONG).show();
           Log.d(ARGUMENTS, ex.getMessage());
        }

        catch (IOException ex) {
            Toast.makeText(context, "Cannot write to the log file!", Toast.LENGTH_LONG).show();
            Log.d(MainActivity.SAVE, ex.getMessage().toString());
        }
    }

    private void saveToLogFile(String number, String text) throws IOException{

            final String STATUS = "Sent";
            File file = new File(MainActivity.LOGFILE);
            FileWriter fw = new FileWriter(file, true);
            StringBuilder builder = new StringBuilder();
            builder.append(number + ";" + text + ";" + STATUS + ";Has been sent at" + new Date() + "\r\n");
            fw.write(builder.toString());
            fw.flush();
            fw.close();
    }

    private void sendMessage(Context context, String number, String message) throws IllegalArgumentException, IOException {
        SmsManager manager = SmsManager.getDefault();
        manager.sendTextMessage(number, null, message, null, null);
        saveToLogFile(number, message);
        Toast.makeText(context, "A scheduled sms has been sent!", Toast.LENGTH_LONG).show();
    }
}
