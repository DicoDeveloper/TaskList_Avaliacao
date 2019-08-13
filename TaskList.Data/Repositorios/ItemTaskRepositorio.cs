using System;
using System.Linq;
using TaskList.Data.Infra;
using TaskList.Modelo.Entidades;
using TaskList.Modelo.Interfaces.Repositorios;

namespace TaskList.Data.Repositorios
{
    partial class ItemTaskRepositorio : IItemTaskRepositorio, IDisposable
    {
        private readonly Contexto _contexto;

        public ItemTaskRepositorio()
        {
            _contexto = new Contexto();
        }

        public IQueryable<ItemTask> Obter()
        {
            return _contexto.Tasks;
        }

        public ItemTask Obter(long id)
        {
            return _contexto.Tasks.Find(id);
        }

        public bool Salvar(ItemTask entidade)
        {
            if (entidade.Id > 0)
            {
                ItemTask task = _contexto.Tasks.Find(entidade.Id);

                if (task == null)
                    return false;

                _contexto.Entry(task).CurrentValues.SetValues(entidade);
            }
            else
            {
                _contexto.Tasks.Add(entidade);
            }

            return _contexto.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
