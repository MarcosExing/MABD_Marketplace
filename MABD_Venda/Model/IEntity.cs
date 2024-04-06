//Este arquivo contém a interface IEntity, que garante que todas as entidades possuam ID. Certos métodos genéricos dependem do id da entidade

namespace Model
{
    /// <summary>
    /// Interface responsável por garantir que todas as entidades que a implementam possuam ID
    /// </summary>
    public interface IEntity
    {
        int id { get; set; }
    }
}
