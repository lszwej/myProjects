package gcm.androidltm.com.gcmnewspaper;

import java.io.IOException;
import java.util.Timer;
import java.util.TimerTask;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.os.PowerManager;
import android.util.Log;

import com.androidltm.gcm.R;
import com.google.android.gcm.GCMBaseIntentService;

public class GCMIntentService {

    public static final String MESSAGE_INTENT = "message";
    public static final String NEW_POST_INTENT = "new_post";
    private static final String TAG = "GCM::Service";
    private final String URL = "http://ux.up.krakow.pl/~tst12/wordpress";
    // Use your PROJECT ID from Google API into SENDER_ID
    public static final String SENDER_ID = "255086254959";

    private static final String PROPERTY_REG_ID = null;

    private static final String PROPERTY_APP_VERSION = null;

    private String regid;
    private String responseBody;

    public GCMIntentService() {
        super(SENDER_ID);
    }

    private void storeRegistrationId(Context context, String regId) {
        final SharedPreferences prefs = getGCMPreferences(context);
        int appVersion = getAppVersion(context);
        Log.i("Px GCM", "Saving regId on app version " + appVersion);
        SharedPreferences.Editor editor = prefs.edit();
        editor.putString(PROPERTY_REG_ID, regId);
        editor.putInt(PROPERTY_APP_VERSION, appVersion);
        editor.commit();
    }

    private void sendRegistrationIdToBackend() {
        HttpClient httpclient = new DefaultHttpClient();


        HttpPost httppost = new HttpPost(URL + "/?regId=" + regid);
        try {
            HttpResponse response = httpclient.execute(httppost);
            responseBody = EntityUtils.toString(response.getEntity());

        } catch (ClientProtocolException e) {

        } catch (IOException e) {
        }
    }

    public String getRegistrationId(Context context) {
        final SharedPreferences prefs = getGCMPreferences(context);
        String registrationId = prefs.getString(PROPERTY_REG_ID, "");
        if (registrationId.isEmpty()) {
            Log.i(TAG, "Registration not found.");
            return "";
        }

        int registeredVersion = prefs.getInt(PROPERTY_APP_VERSION,
                Integer.MIN_VALUE);
        int currentVersion = getAppVersion(context);
        if (registeredVersion != currentVersion) {
            Log.i(TAG, "App version changed.");
            return "";
        }
        return registrationId;
    }

    private SharedPreferences getGCMPreferences(Context context) {
        return getSharedPreferences(GCMMainActivity.class.getSimpleName(),
                Context.MODE_PRIVATE);
    }

    private static int getAppVersion(Context context) {
        try {
            PackageInfo packageInfo = context.getPackageManager()
                    .getPackageInfo(context.getPackageName(), 0);
            return packageInfo.versionCode;
        } catch (PackageManager.NameNotFoundException e) {
            throw new RuntimeException("Could not get package name: " + e);
        }
    }

    @Override
    protected void onRegistered(Context context, String registrationId) {

        Log.i(TAG, "onRegistered: registrationId=" + registrationId);
        if (!registrationId.isEmpty()) {
            regid = registrationId;
            sendRegistrationIdToBackend();
            // storeRegistrationId(context, regid);
        }
    }

    @Override
    protected void onUnregistered(Context context, String registrationId) {

        Log.i(TAG, "onUnregistered: registrationId=" + registrationId);
    }

    private void wakeDevice(Context context)
    {
        // Wake Android Device when notification received
        PowerManager pm = (PowerManager) context
                .getSystemService(Context.POWER_SERVICE);
        final PowerManager.WakeLock mWakelock = pm.newWakeLock(
                PowerManager.FULL_WAKE_LOCK
                        | PowerManager.ACQUIRE_CAUSES_WAKEUP, "GCM_PUSH");
        mWakelock.acquire();

        // Timer before putting Android Device to sleep mode.
        Timer timer = new Timer();
        TimerTask task = new TimerTask() {
            public void run() {
                mWakelock.release();
            }
        };
        timer.schedule(task, 5000);
    }

    @Override
    protected void onMessage(Context context, Intent data) {


        Intent intent = new Intent(this, GCMMessageView.class);
        // Message from PHP server
        String message = data.getStringExtra(MESSAGE_INTENT);
        if(message==null){
            message = data.getStringExtra(NEW_POST_INTENT);
            intent.putExtra(NEW_POST_INTENT, message);
        }
        else
            intent.putExtra(MESSAGE_INTENT, message);

        // Open a new activity called GCMMessageView

        // Pass data to the new activity

        // Starts the activity on notification click
        PendingIntent pIntent = PendingIntent.getActivity(this, 0, intent,
                PendingIntent.FLAG_UPDATE_CURRENT);
        // Create the notification with a notification builder
        Notification notification = new Notification.Builder(this)
                .setSmallIcon(R.drawable.ic_launcher)
                .setWhen(System.currentTimeMillis())
                .setContentTitle("Android GCM").setContentText(message)
                .setContentIntent(pIntent).build();

        // Remove the notification on click
        notification.flags |= Notification.FLAG_AUTO_CANCEL;

        NotificationManager manager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
        manager.notify(R.string.app_name, notification);
        wakeDevice(context);
    }

    @Override
    protected void onError(Context arg0, String errorId) {

        Log.e(TAG, "onError: errorId=" + errorId);
    }


}
