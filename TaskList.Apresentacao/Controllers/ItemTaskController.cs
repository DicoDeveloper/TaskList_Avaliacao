using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskList.Modelo.Entidades;
using TaskList.Modelo.Enumeradores;
using TaskList.Modelo.Interfaces.Servicos;

namespace TaskList.Apresentacao.Controllers
{
    public class ItemTaskController : Controller
    {
        private readonly IItemTaskServico _itemTaskServico;

        public ItemTaskController(IItemTaskServico itemTaskServico)
        {
            _itemTaskServico = itemTaskServico;
        }

        public ActionResult Index()
        {
            return View(_itemTaskServico.Obter().Where(t => t.Status != StatusTask.Cancelado).ToList());
        }

        public JsonResult Salvar(List<ItemTask> Task)
        {
            string erro = string.Empty;

            try
            {
                _itemTaskServico.Salvar(Task);
            }
            catch(Exception ex)
            {
                erro = ex.Message;
            }

            return Json(new
            {
                Erro = erro
            }, JsonRequestBehavior.AllowGet);
        }
    }
}