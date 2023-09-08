using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaNegocio;
using RemesasEDM;
using System.Web.Mvc;

namespace LinkUp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Clientes()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public JsonResult ListarClientes()
        {
            List<Clientes> oLista = new List<Clientes>();

            oLista = new CNClientes().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

    }
}