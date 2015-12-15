package gcm.androidltm.com.gcmnewspaper;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.webkit.WebSettings;
import android.webkit.WebView;


public class GCMMessageView extends Activity {

    private WebView browser;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_gcmmessage_view);

        browser = (WebView) findViewById(R.id.webView1);
        browser.getSettings().setAppCacheEnabled(true);
        browser.getSettings().setAppCachePath(this.getCacheDir().toString());
        browser.getSettings().setDomStorageEnabled(true);
        browser.getSettings().setCacheMode(WebSettings.LOAD_DEFAULT);
        browser.getSettings().setJavaScriptEnabled(true);

        try {
            Intent i = getIntent();
            boolean res = i.getBooleanExtra(GCMWebpagesList.CACHEVAL, false);

            if (res) {
                browser.getSettings().setCacheMode(
                        WebSettings.LOAD_CACHE_ELSE_NETWORK);
                String address = i.getStringExtra(GCMWebpagesList.CACHEADDR);
                browser.loadUrl(address);
            } else {
                String address = i
                        .getStringExtra(GCMIntentService.NEW_POST_INTENT);
                if (address == null)
                    address = i.getStringExtra(GCMIntentService.MESSAGE_INTENT);
                else {
                    String[] addresses = address.split(";");
                    address = addresses[1];
                }
                saveAddress(address);
                browser.loadUrl(address);
            }
        }

        catch (IOException e) {
            AlertDialog.Builder messBuilder = new AlertDialog.Builder(this);
            messBuilder.setTitle("Cannot find the file");
            messBuilder.setMessage("Cannot load webpages from the file");
            messBuilder.setPositiveButton("OK",
                    new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            GCMMessageView.this.finish();
                        }
                    });
            messBuilder.show();
        }

    }

    private void saveAddress(String address) throws IOException {
        BufferedWriter bw = new BufferedWriter(new FileWriter(
                GCMMainActivity.CACHEPATH, true));

        bw.write(address + "\r\n");
        bw.flush();
        bw.close();
    }



}
