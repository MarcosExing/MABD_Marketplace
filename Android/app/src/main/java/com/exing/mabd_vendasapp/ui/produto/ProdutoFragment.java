package com.exing.mabd_vendasapp.ui.produto;

import androidx.lifecycle.ViewModelProvider;

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
import android.view.contentcapture.ContentCaptureCondition;
import android.widget.Button;

import com.exing.mabd_vendasapp.Item;
import com.exing.mabd_vendasapp.ItemAdapter;
import com.exing.mabd_vendasapp.OnDetalhesClickListener;
import com.exing.mabd_vendasapp.OnEditarClickListener;
import com.exing.mabd_vendasapp.ProdutoAdicionarActivity;
import com.exing.mabd_vendasapp.ProdutoDetalhesActivity;
import com.exing.mabd_vendasapp.ProdutoEditarActivity;
import com.exing.mabd_vendasapp.R;

import java.util.ArrayList;
import java.util.List;

public class ProdutoFragment extends Fragment implements OnEditarClickListener, OnDetalhesClickListener {

    Activity context;

    private ProdutoViewModel mViewModel;

    public static ProdutoFragment newInstance() {
        return new ProdutoFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        context = getActivity();

        return inflater.inflate(R.layout.fragment_produto, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        Button btnAdicionar = view.findViewById(R.id.btnAdicionar);
        btnAdicionar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(context, ProdutoAdicionarActivity.class);
                startActivity(intent);
            }
        });

        RecyclerView recyclerView = view.findViewById(R.id.listProdutos);
        List<Item> itemList = new ArrayList<>();
        itemList.add(new Item("Informação do produto"));
        itemList.add(new Item("Informação de outro produto"));

        ItemAdapter adapter = new ItemAdapter(itemList, this, this);
        recyclerView.setAdapter(adapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(context));
    }

    @Override
    public void onDetalhesClick(int position) {
        Intent intent = new Intent(context, ProdutoDetalhesActivity.class);
        startActivity(intent);
    }

    @Override
    public void onEditarClick(int position) {
        Intent intent = new Intent(context, ProdutoEditarActivity.class);
        startActivity(intent);
    }
}