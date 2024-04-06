package com.exing.mabd_vendasapp.ui.endereco;

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

import com.exing.mabd_vendasapp.EnderecoAdicionarActivity;
import com.exing.mabd_vendasapp.EnderecoEditarActivity;
import com.exing.mabd_vendasapp.Item;
import com.exing.mabd_vendasapp.ItemAdapter;
import com.exing.mabd_vendasapp.OnDetalhesClickListener;
import com.exing.mabd_vendasapp.OnEditarClickListener;
import com.exing.mabd_vendasapp.R;

import java.util.ArrayList;
import java.util.List;

public class EnderecoFragment extends Fragment implements OnEditarClickListener{

    Activity context;

    private EnderecoViewModel mViewModel;

    public static EnderecoFragment newInstance() {
        return new EnderecoFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        context = getActivity();

        return inflater.inflate(R.layout.fragment_endereco, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        Button btnAdicionar = view.findViewById(R.id.btnAdicionar);
        btnAdicionar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(context, EnderecoAdicionarActivity.class);
                startActivity(intent);
            }
        });

        RecyclerView recyclerView = view.findViewById(R.id.listEnderecos);
        List<Item> itemList = new ArrayList<>();
        itemList.add(new Item("Informação do produto"));
        itemList.add(new Item("Informação de outro produto"));

        ItemAdapter adapter = new ItemAdapter(itemList, this);
        recyclerView.setAdapter(adapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(context));
    }

    @Override
    public void onEditarClick(int position) {
        Intent intent = new Intent(context, EnderecoEditarActivity.class);
        startActivity(intent);
    }
}