package com.exing.mabd_vendasapp;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class ItemAdapter extends RecyclerView.Adapter<ItemAdapter.ViewHolder> {
    private List<Item> itemList;
    private OnEditarClickListener editarClickListener;
    private OnDetalhesClickListener detalhesClickListener;
    private boolean showEditarButton = false;
    private boolean showDetalhesButton = false;
    private boolean showDeletarButton = false;

    public ItemAdapter(List<Item> itemList, OnEditarClickListener editarClickListener,
                       OnDetalhesClickListener detalhesClickListener) {
        this.itemList = itemList;
        this.editarClickListener = editarClickListener;
        showEditarButton = true;
        this.detalhesClickListener = detalhesClickListener;
        showDetalhesButton = true;
    }

    public ItemAdapter(List<Item> itemList, OnEditarClickListener editarClickListener) {
        this.itemList = itemList;
        this.editarClickListener = editarClickListener;
        showEditarButton = true;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.list_item, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Item item = itemList.get(position);
        holder.txtItemInfo.setText(item.getInfo());

        holder.btnEditar.setVisibility(showEditarButton ? View.VISIBLE : View.GONE);
        holder.btnDetalhes.setVisibility(showDetalhesButton ? View.VISIBLE : View.GONE);

        holder.btnEditar.setOnClickListener(v -> {
            if (editarClickListener != null) {
                editarClickListener.onEditarClick(position);
            }
        });

        holder.btnDetalhes.setOnClickListener(v -> {
            if (detalhesClickListener != null) {
                detalhesClickListener.onDetalhesClick(position);
            }
        });
    }

    @Override
    public int getItemCount() {
        return itemList.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder {
        TextView txtItemInfo;
        Button btnEditar;
        Button btnDetalhes;
        Button btnDeletar;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            txtItemInfo = itemView.findViewById(R.id.txtItemInfo);
            btnEditar = itemView.findViewById(R.id.btnEditar);
            btnDetalhes = itemView.findViewById(R.id.btnDetalhes);
            btnDeletar = itemView.findViewById(R.id.btnDeletar);
        }
    }
}

