package com.exing.mabd_vendasapp.ui.home;

import static androidx.navigation.fragment.FragmentKt.findNavController;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.lifecycle.ViewModelProvider;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.navigation.ui.NavigationUI;

import com.exing.mabd_vendasapp.EnderecoAdicionarActivity;
import com.exing.mabd_vendasapp.R;
import com.exing.mabd_vendasapp.databinding.FragmentHomeBinding;
import com.exing.mabd_vendasapp.ui.endereco.EnderecoFragment;

public class HomeFragment extends Fragment {

    Activity context;

    private NavController navController;

    private FragmentHomeBinding binding;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        HomeViewModel homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);

        context = getActivity();

        binding = FragmentHomeBinding.inflate(inflater, container, false);
        View root = binding.getRoot();

        return root;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        Button btnEndereco = view.findViewById(R.id.btnEndereco);
        btnEndereco.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Navigation.findNavController(v).navigate(R.id.nav_endereco);
            }
        });

        Button btnCliente = view.findViewById(R.id.btnCliente);
        btnCliente.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Navigation.findNavController(v).navigate(R.id.nav_cliente);
            }
        });

        Button btnVendedor = view.findViewById(R.id.btnVendedor);
        btnVendedor.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Navigation.findNavController(v).navigate(R.id.nav_vendedor);
            }
        });

        Button btnCategoria = view.findViewById(R.id.btnCategoria);
        btnCategoria.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Navigation.findNavController(v).navigate(R.id.nav_categoria);
            }
        });

        Button btnProduto = view.findViewById(R.id.btnProduto);
        btnProduto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Navigation.findNavController(v).navigate(R.id.nav_produto);
            }
        });

        Button btnCarrinho = view.findViewById(R.id.btnCarrinho);
        btnCarrinho.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Navigation.findNavController(v).navigate(R.id.nav_carrinho);
            }
        });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}