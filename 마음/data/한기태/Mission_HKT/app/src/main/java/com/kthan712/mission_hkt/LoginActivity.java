package com.kthan712.mission_hkt;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class LoginActivity extends AppCompatActivity {

    EditText editText, editText2;
    Button button;
    Intent intent = getIntent();


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        EditText editText = findViewById(R.id.editText);
        EditText editText2 = findViewById(R.id.editText2);
        Button button = findViewById(R.id.button);

        if(editText==null || editText2==null)
            Toast.makeText(getApplicationContext(),"사용자이름과 비밀번호를 입력하세요", ).show();
    }
}
