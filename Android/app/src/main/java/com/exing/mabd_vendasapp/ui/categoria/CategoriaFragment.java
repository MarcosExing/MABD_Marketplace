package com.exing.mabd_vendasapp.ui.categoria;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.exing.mabd_vendasapp.CategoriaAdicionarActivity;
import com.exing.mabd_vendasapp.CategoriaEditarActivity;
import com.exing.mabd_vendasapp.Item;
import com.exing.mabd_vendasapp.ItemAdapter;
import com.exing.mabd_vendasapp.OnDetalhesClickListener;
import com.exing.mabd_vendasapp.OnEditarClickListener;
import com.exing.mabd_vendasapp.R;

import java.util.ArrayList;
import java.util.List;

public class CategoriaFragment extends Fragment implements OnEditarClickListener {

    Activity context;

    private CategoriaViewModel mViewModel;

    public static CategoriaFragment newInstance() {
        return new CategoriaFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        context = getActivity();

        return inflater.inflate(R.layout.fragment_categoria, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        Button btnAdicionar = view.findViewById(R.id.btnAdicionar);
        btnAdicionar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(context, CategoriaAdicionarActivity.class);
                startActivity(intent);
            }
        });

        RecyclerView recyclerView = view.findViewById(R.id.listCategorias);
        List<Item> itemList = new ArrayList<>();
        itemList.add(new Item("Informação da categoria"));
        itemList.add(new Item("Informação de outra categoria"));

        ItemAdapter adapter = new ItemAdapter(itemList, this);
        recyclerView.setAdapter(adapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(context));
    }

    @Override
    public void onEditarClick(int position) {
        Intent intent = new Intent(context, CategoriaEditarActivity.class);
        startActivity(intent);
    }
}