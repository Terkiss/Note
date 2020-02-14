package com.kthan712.mission_hkt;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.Toast;

public class MenuActivity extends AppCompatActivity {

    Button button1, button3, button4;
    Intent intent = getIntent();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        Button button1 = findViewById(R.id.button1);
        Button button3 = findViewById(R.id.button3);
        Button button4 = findViewById(R.id.button4);


        Toast.makeText(getApplicationContext(), "사용자 이름 : " + LoginActivity : editext + "님이 로그인하였습니다." ,  ).show();




    }
}
