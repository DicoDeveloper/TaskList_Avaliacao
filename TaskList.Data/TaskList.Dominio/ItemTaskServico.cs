using System.Linq;
using TaskList.Modelo.Entidades;
using TaskList.Modelo.Enumeradores;
using TaskList.Modelo.Interfaces.Repositorios;
using TaskList.Modelo.Interfaces.Servicos;

namespace TaskList.Dominio
{
    internal class ItemTaskServico : IItemTaskServico
    {
        private readonly IItemTaskRepositorio _itemTaskRepositorio;

        public ItemTaskServico(IItemTaskRepositorio itemTaskRepositorio)
        {
            _itemTaskRepositorio = itemTaskRepositorio;
        }

        public IQueryable<ItemTask> Obter()
        {
            return _itemTaskRepositorio.Obter();
        }

        public ItemTask Obter(long id)
        {
            return _itemTaskRepositorio.Obter(id);
        }

        public IQueryable<ItemTask> ObterNormais()
        {
            return _itemTaskRepositorio.Obter().Where(t => t.Status == StatusTask.Normal);
        }

        public IQueryable<ItemTask> ObterConcluidos()
        {
            return _itemTaskRepositorio.Obter().Where(t => t.Status == StatusTask.Concluido);
        }

        public IQueryable<ItemTask> ObterCancelados()
        {
            return _itemTaskRepositorio.Obter().Where(t => t.Status == StatusTask.Cancelado);
        }

        public bool Salvar(ItemTask task)
        {
            return _itemTaskRepositorio.Salvar(task);
        }

        public bool Concluir(long id)
        {
            ItemTask task = _itemTaskRepositorio.Obter(id);
            task.Status = StatusTask.Concluido;
            return _itemTaskRepositorio.Salvar(task);
        }

        public bool Cancelar(long id)
        {
            ItemTask task = _itemTaskRepositorio.Obter(id);
            task.Status = StatusTask.Cancelado;
            return _itemTaskRepositorio.Salvar(task);
        }
    }
}
