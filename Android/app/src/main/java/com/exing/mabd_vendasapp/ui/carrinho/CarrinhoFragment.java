package com.exing.mabd_vendasapp.ui.carrinho;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.telephony.ims.ImsMmTelManager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.exing.mabd_vendasapp.CarrinhoAdicionarActivity;
import com.exing.mabd_vendasapp.CarrinhoDetalhesActivity;
import com.exing.mabd_vendasapp.CarrinhoEditarActivity;
import com.exing.mabd_vendasapp.Item;
import com.exing.mabd_vendasapp.ItemAdapter;
import com.exing.mabd_vendasapp.OnDetalhesClickListener;
import com.exing.mabd_vendasapp.OnEditarClickListener;
import com.exing.mabd_vendasapp.R;

import java.util.ArrayList;
import java.util.List;

public class CarrinhoFragment extends Fragment implements OnEditarClickListener, OnDetalhesClickListener {

    Activity context;

    private CarrinhoViewModel mViewModel;

    public static CarrinhoFragment newInstance() {
        return new CarrinhoFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        context = getActivity();

        return inflater.inflate(R.layout.fragment_carrinho, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        Button btnAdicionar = view.findViewById(R.id.btnAdicionar);
        btnAdicionar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getActivity(), CarrinhoAdicionarActivity.class);
                startActivity(intent);
            }
        });

        RecyclerView recyclerView = view.findViewById(R.id.listCarrinhos);
        List<Item> itemList = new ArrayList<>();
        itemList.add(new Item("Informação do carrinho"));
        itemList.add(new Item("Informação de outro carrinho"));

        ItemAdapter adapter = new ItemAdapter(itemList, this, this);
        recyclerView.setAdapter(adapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(context));
    }

    @Override
    public void onDetalhesClick(int position) {
        Intent intent = new Intent(context, CarrinhoDetalhesActivity.class);
        startActivity(intent);
    }

    @Override
    public void onEditarClick(int position) {
        Intent intent = new Intent(context, CarrinhoEditarActivity.class);
        startActivity(intent);
    }
}