using System.Linq;
using TaskList.Modelo.Entidades;

namespace TaskList.Modelo.Interfaces.Repositorios
{
    public interface IItemTaskRepositorio
    {
        IQueryable<ItemTask> Obter();
        ItemTask Obter(long id);
        bool Salvar(ItemTask task);
    }
}
