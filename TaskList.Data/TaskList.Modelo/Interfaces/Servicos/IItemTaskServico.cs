using System.Linq;
using TaskList.Modelo.Entidades;

namespace TaskList.Modelo.Interfaces.Servicos
{
    public interface IItemTaskServico
    {
        IQueryable<ItemTask> Obter();
        ItemTask Obter(long id);
        IQueryable<ItemTask> ObterNormais();
        IQueryable<ItemTask> ObterConcluidos();
        IQueryable<ItemTask> ObterCancelados();
        bool Salvar(ItemTask task);
        bool Concluir(long id);
        bool Cancelar(long id);
    }
}
