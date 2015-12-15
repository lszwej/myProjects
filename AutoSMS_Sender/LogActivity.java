package com.example.project_zaliczeniowy.sms;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;



public class LogActivity extends Activity {


    private static final String READ = "READ_ERROR";
    private TextView logList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_log);

        logList = (TextView) findViewById(R.id.logView);
        try {
            readFromLog();
        } catch (IOException ex) {
            Toast.makeText(this, "Cannot read from a log file!", Toast.LENGTH_LONG).show();
            Log.d(READ, ex.getMessage().toString());
        }
    }

    private void readFromLog() throws IOException {
        File file = new File(MainActivity.LOGFILE);
        BufferedReader br = new BufferedReader(new FileReader(file));
        StringBuilder builder = new StringBuilder();
        String line;
        while ((line = br.readLine()) != null)
        {
            builder.append(line + "\r\n");
        }
        br.close();
        logList.setText(builder.toString());
    }

}
