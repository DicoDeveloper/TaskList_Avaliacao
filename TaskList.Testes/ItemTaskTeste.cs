using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TaskList.Modelo.Entidades;
using TaskList.Modelo.Enumeradores;
using TaskList.Modelo.Injetor;
using TaskList.Modelo.Interfaces.Servicos;

namespace TaskList.Testes
{
    [TestClass]
    public class ItemTaskTeste
    {
        private readonly IItemTaskServico _itemTaskServico;

        public ItemTaskTeste()
        {
            _itemTaskServico = IoC.Resolve<IItemTaskServico>();
        }

        [TestMethod]
        public void ObterTodos()
        {
            _itemTaskServico.Obter();
        }

        [TestMethod]
        public void Salvar()
        {
            ItemTask task = _itemTaskServico.Obter().SingleOrDefault(t => t.Titulo.Equals("Teste task 001")) ?? new ItemTask { Titulo = "Teste task 001" };

            _itemTaskServico.Salvar(task);

            Assert.IsTrue(task.Id > 0);
            Assert.AreEqual(task.Status, StatusTask.Normal);
            Assert.AreEqual(task.Titulo, "Teste task 001");
        }

        [TestMethod]
        public void Concluir()
        {
            ItemTask task = _itemTaskServico.Obter().SingleOrDefault(t => t.Titulo.Equals("Teste task 002")) ?? new ItemTask { Titulo = "Teste task 002" };

            _itemTaskServico.Salvar(task);
            _itemTaskServico.Concluir(task.Id);

            Assert.AreEqual(task.Status, StatusTask.Concluido);
            Assert.AreEqual(task.Titulo, "Teste task 002");
        }

        [TestMethod]
        public void Cancelar()
        {
            ItemTask task = _itemTaskServico.Obter().SingleOrDefault(t => t.Titulo.Equals("Teste task 003")) ?? new ItemTask { Titulo = "Teste task 003" };

            _itemTaskServico.Salvar(task);
            _itemTaskServico.Cancelar(task.Id);

            Assert.AreEqual(task.Status, StatusTask.Cancelado);
            Assert.AreEqual(task.Titulo, "Teste task 003");
        }

        [TestMethod]
        public void ObterNormais()
        {
            Assert.IsFalse(_itemTaskServico.ObterNormais().Any(t => t.Status != StatusTask.Normal));
        }

        [TestMethod]
        public void ObterConcluidos()
        {
            Assert.IsFalse(_itemTaskServico.ObterConcluidos().Any(t => t.Status != StatusTask.Concluido));
        }

        [TestMethod]
        public void ObterCancelados()
        {
            Assert.IsFalse(_itemTaskServico.ObterCancelados().Any(t => t.Status != StatusTask.Cancelado));
        }
    }
}
