using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinkupCN.CN;
using LinkupEDM.AppModel;
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

            oLista = new ClientesCN().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarClientes(Clientes obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id == 0)
            {
                resultado = new ClientesCN().Agregar(obj, out mensaje);
            }
            else 
            {
                resultado = new ClientesCN().Editar(obj, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarClientes(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new ClientesCN().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}