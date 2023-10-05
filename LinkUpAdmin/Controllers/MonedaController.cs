using LinkupCN.CN;
using LinkupEDM.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LinkUpAdmin.Controllers
{
    public class MonedaController : Controller
    {
        // GET: Moneda
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarMonedas()
        {
            
            List<Moneda> oLista = new List<Moneda>();

            oLista = new MonedaCN().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult GuardarMonedas(Moneda obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Moneda == 0)
            {
                resultado = new MonedaCN().Agregar(obj, out mensaje);
            }
            else
            {
                resultado = new MonedaCN().Editar(obj, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMonedas(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new MonedaCN().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}