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
        public ActionResult Index(string usuario,string contraseña)
        {
           Admin oAdmin= new Admin();
            oAdmin = new AdminCN().Listar().Where(u => u.Usuario == usuario && u.Contraseña == RecursosCN.ConvertirSha256(contraseña)).FirstOrDefault();
            if(oAdmin == null)
            {
                ViewBag.Error = "Error";
                return View();
            }
            else
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Home");
            }
        }

      
     
    }
}