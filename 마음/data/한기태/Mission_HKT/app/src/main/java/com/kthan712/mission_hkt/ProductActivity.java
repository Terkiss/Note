package com.kthan712.mission_hkt;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;

public class ProductActivity extends AppCompatActivity {

    Button button2, button3;
    Intent intent = getIntent();



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_product);


        Button button2 = findViewById(R.id.button2);
        Button button3 = findViewById(R.id.button3);
    }
}
