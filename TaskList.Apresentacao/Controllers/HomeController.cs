using System.Web.Mvc;

namespace TaskList.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "ItemTask");
        }
    }
}