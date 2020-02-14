package com.dnf.mission_kwj;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

public class LoginActivity extends AppCompatActivity {
    EditText editText1;
    EditText editText2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        editText1 = findViewById(R.id.editText1);
        editText2 = findViewById(R.id.editText2);


        String 아이디 = editText1.getText().toString();
        String 비밀번호 = editText2.getText().toString();



        Button 버튼_로그인 = findViewById(R.id.button);

        버튼_로그인.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(editText1.getText().toString().length()==0 | editText2.getText().toString().length()==0){
                    Toast.makeText(getApplicationContext(),"사용자 , 이름과 비밀번호를 입력하세요",Toast.LENGTH_SHORT).show();
                }else {
                    Intent 인텐트 = new Intent(getApplicationContext(),MenuActivity.class);
                    인텐트.putExtra("사용자명", editText1.getText().toString());
                    startActivityForResult(인텐트,RESULT_OK);
                }
            }
        });
    }
}
