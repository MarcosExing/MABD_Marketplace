// Este arquivo contém a interface IRepository, que é responsável pela estrutura CRUD.

using System.Collections.Generic;

namespace DAL
{
    /// <summary>
    /// Interface responsável por oferecer a estrutura dos métodos CRUD.
    /// </summary>
    public interface IRepository<T>
    {
        bool Adicionar(T entidade);
        bool Atualizar(T entidade);
        bool Excluir(T entidade);
        T ObterPorId(int id);
        List<T> ObterTodos();
    }
}
