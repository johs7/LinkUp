using System;
using System.Collections.Generic;
using System.Linq;
using LinkupCN.CN;
using System.Web;
using System.Web.Mvc;
using LinkupEDM.AppModel;
using LinkupDAO.DAO;

namespace LinkUp.Controllers
{
    public class AccesoController : Controller
    {
        private static string sesion = "";
        private ClientesDAO clientesDAO = new ClientesDAO();
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo,string clave)
        {
            Clientes oClientes= new Clientes();
            oClientes = new ClientesCN().Listar().Where(u => u.Correo == correo &&
            u.Clave == RecursosCN.ConvertirSha256(clave)).FirstOrDefault();
            sesion = correo;
            if(oClientes == null)
            {
                ViewBag.Error = "Correo o contraseña invalida";
                return View();
            }
            else
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Home");
            }
            return View();  
        }

        public JsonResult GetSesion()
        {
            Clientes clientes = new Clientes();
            clientes = clientesDAO.GetClientes(sesion);

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarClientes(Clientes obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.Id == 0)
                resultado = new ClientesCN().Agregar(obj, out mensaje);
            else
                resultado = new ClientesCN().Editar(obj, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}