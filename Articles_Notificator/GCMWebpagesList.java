package gcm.androidltm.com.gcmnewspaper;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;


public class GCMWebpagesList extends Activity {

    public static final String CACHEADDR = "cacheaddr";
    public static final String CACHEVAL = "cacheval";
    private ListView pagesView;
    private List<String> pagesList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_gcmwebpages_list);

        pagesView = (ListView) findViewById(R.id.listView1);
        pagesList = new ArrayList<String>();

        try
        {
            createList();
        }

        catch (IOException e) {

            AlertDialog.Builder messBuilder = new AlertDialog.Builder(this);
            messBuilder.setTitle("Cannot open/find the file");
            messBuilder.setMessage(e.getMessage());
            messBuilder.setPositiveButton("OK",
                    new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int id) {
                            GCMWebpagesList.this.finish();
                        }
                    });
            AlertDialog message = messBuilder.create();
            message.show();

        }
    }


    private void readWebpages() throws IOException
    {
        BufferedReader br = new BufferedReader(new FileReader(
                GCMMainActivity.CACHEPATH));

        String line;
        while ((line = br.readLine()) != null) {
            if (!line.isEmpty())
                pagesList.add(line);
        }

        br.close();
    }

    private void createList() throws IOException
    {

        readWebpages();
        if (pagesList.size() != 0) {
            ListAdapter adapter = new ArrayAdapter<String>(this,
                    android.R.layout.simple_list_item_single_choice, pagesList);
            pagesView.setAdapter(adapter);

            pagesView.setOnItemClickListener(new OnItemClickListener() {

                @Override
                public void onItemClick(AdapterView<?> parent, View view,
                                        int position, long id) {

                    String address = (String) pagesView
                            .getItemAtPosition(position);
                    Intent intent = new Intent(getBaseContext(),
                            GCMMessageView.class);
                    intent.putExtra(CACHEADDR, address);
                    intent.putExtra(CACHEVAL, true);
                    startActivity(intent);
                }
            });
        }
        else
        {
            Toast.makeText(getBaseContext(),
                    "There's no saved website addressess", Toast.LENGTH_LONG).show();
            GCMWebpagesList.this.finish();
        }
    }

}
