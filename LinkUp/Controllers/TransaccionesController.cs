using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkupEDM.AppModel;
using LinkupCN.CN;

namespace LinkUp.Controllers
{
    public class TransaccionesController : Controller
    {
        // GET: Transacciones
        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public JsonResult ListarClientes()
        {
            List<Envio> oLista = new List<Envio>();

            oLista = new TransaccionCN().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarTransacciones(Envio obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Envio == null)
            {
                resultado = new TransaccionCN().Agregar(obj, out mensaje);
            }
            else
            {
                resultado = new TransaccionCN().Editar(obj, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarClientes(string id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new TransaccionCN().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}