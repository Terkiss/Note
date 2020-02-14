package com.dnf.mission_kwj;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class MenuActivity extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        Intent 인텐트 = getIntent();
        String 사용자명 = 인텐트.getStringExtra("사용자명");


        Toast.makeText(getApplicationContext(),사용자명+"님이 로그인 하셨습니다.",Toast.LENGTH_SHORT).show();

        Button 버튼_고객관리 = findViewById(R.id.button1);
        Button 버튼_매출관리 = findViewById(R.id.button2);
        Button 버튼_상품관리 = findViewById(R.id.button3);

        버튼_고객관리.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent 인텐트 = new Intent(getApplicationContext(), CustomerActivity.class);
                startActivityForResult(인텐트,1001);
            }
        });

        버튼_매출관리.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent 인텐트 = new Intent(getApplicationContext(), RevenueActivity.class);
                startActivityForResult(인텐트,1002);
            }
        });

        버튼_상품관리.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent 인텐트 = new Intent(getApplicationContext(), ProductActivity.class);
                startActivityForResult(인텐트,1003);
            }
        });



    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(requestCode == 1001){
            Toast.makeText(getApplicationContext(),"고객관리 응답 : Customer result massage is OK!",Toast.LENGTH_SHORT).show();
        }if(requestCode == 1002){
            Toast.makeText(getApplicationContext(),"고객관리 응답 : Revenue result massage is OK!",Toast.LENGTH_SHORT).show();
        }if(requestCode == 1003){
            Toast.makeText(getApplicationContext(),"고객관리 응답 : Revenue result massage is OK!",Toast.LENGTH_SHORT).show();
        }
    }
}
