package gcm.androidltm.com.gcmnewspaper;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.google.android.gcm.GCMRegistrar;


public class GCMMainActivity extends Activity {

    public static final String CACHEPATH = "/data/data/com.androidltm.gcm/cache/websites.txt";
    private final String TAG = "GCM Tutorial::Activity";
    private Button regbtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_gcmmain);
        regbtn = (Button) findViewById(R.id.register);

        try {
            checkFile();
            if (!checkConnection()) {
                Intent i = new Intent(getBaseContext(), GCMWebpagesList.class);
                startActivity(i);
            }
            registerDevice();

        } catch (UnsupportedOperationException e) {

            AlertDialog.Builder messBuilder = new AlertDialog.Builder(this);
            messBuilder.setTitle("Cannot run the application");
            messBuilder.setMessage(e.getMessage());
            messBuilder.setPositiveButton("OK",
                    new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int id) {
                            GCMMainActivity.this.finish();
                        }
                    });
            AlertDialog message = messBuilder.create();
            message.show();
        }

        catch (IOException e) {

            AlertDialog.Builder messBuilder = new AlertDialog.Builder(this);
            messBuilder.setTitle("Cannot open/find the file");
            messBuilder.setMessage(e.getMessage());
            messBuilder.setPositiveButton("OK",
                    new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int id) {

                        }
                    });
            AlertDialog message = messBuilder.create();
            message.show();
        }

    }

    private void checkFile() throws IOException {

        File file = new File(GCMMainActivity.CACHEPATH);

        if (!file.exists()) {

            Toast.makeText(
                    this,
                    "File has been created in directory: "
                            + GCMMainActivity.CACHEPATH, Toast.LENGTH_LONG)
                    .show();
            BufferedWriter bw = new BufferedWriter(new FileWriter(file));
            bw.close();
        }
    }

    public boolean checkConnection() {
        ConnectivityManager manager = (ConnectivityManager) this
                .getSystemService(GCMMainActivity.CONNECTIVITY_SERVICE);
        NetworkInfo info = manager.getActiveNetworkInfo();
        return info != null && info.isConnected();

    }

    private void registerDevice() {
        GCMRegistrar.checkDevice(this);
        GCMRegistrar.checkManifest(this);

        if (regbtn != null)
            regbtn.setOnClickListener(new View.OnClickListener() {

                @Override
                public void onClick(View v) {
                    Log.i(TAG, "Registering device");
                    // Sender ID will be registered into GCMRegistrar
                    GCMRegistrar.register(GCMMainActivity.this,
                            GCMIntentService.SENDER_ID);
                }
            });
    }



}
