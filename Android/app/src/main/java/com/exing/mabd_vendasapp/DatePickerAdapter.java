package com.exing.mabd_vendasapp;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.widget.Button;

import java.util.Calendar;

public class DatePickerAdapter {

    public static void showDatePickerDialog(Activity context, Button btnSelectDate) {
        final Calendar calendar = Calendar.getInstance();
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int dayOfMonth = calendar.get(Calendar.DAY_OF_MONTH);

        DatePickerDialog datePickerDialog = new DatePickerDialog(
                context,
                new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(android.widget.DatePicker view, int year, int month, int dayOfMonth) {
                        String selectedDate = dayOfMonth + "/" + getMonth(month + 1) + "/" + year;
                        btnSelectDate.setText(selectedDate);
                    }
                },
                year, month, dayOfMonth);

        datePickerDialog.show();
    }

    private static String getMonth (int month) {
        switch (month){
            case 1:
                return "JAN";
            case 2:
                return "FEV";
            case 3:
                return "MAR";
            case 4:
                return "ABR";
            case 5:
                return "MAI";
            case 6:
                return "JUN";
            case 7:
                return "JUL";
            case 8:
                return "AGO";
            case 9:
                return "OUT";
            case 10:
                return "SET";
            case 11:
                return "NOV";
            case 12:
                return "DEZ";
        }

        return "MÊS INVÁLIDO";
    }
}
