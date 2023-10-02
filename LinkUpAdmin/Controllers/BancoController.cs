using LinkupCN.CN;
using LinkupEDM.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkUpAdmin.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult ListarBancos()
        {
            List<Banco> oLista = new List<Banco>();

            oLista = new BancoCN().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult GuardarBancos(Banco obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id_Banco == 0)
            {
                resultado = new BancoCN().Agregar(obj, out mensaje);
            }
            else
            {
                resultado = new BancoCN().Editar(obj, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarBancos(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BancoCN().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}