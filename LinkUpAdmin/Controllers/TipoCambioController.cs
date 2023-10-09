using LinkupCN.CN;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace LinkUpAdmin.Controllers
{
    public class TipoCambioController : Controller
    {
        // GET: TipoCambio
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> MostrarTipoCambio(int year, int month, int day)
        {
            try
            {
                double tipoCambio = await new TipoCambioCN().ObtenerTipoCambio(year, month, day);

                var result = new { TipoCambio = tipoCambio };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var errorResult = new { ErrorMessage = "Error al obtener el tipo de cambio: " + ex.Message };

                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<ActionResult> MostrarTipoCambioMes(int year, int month)
        {
            try
            {
                XDocument tipoCambioData = await new TipoCambioCN().ObtenerTipoCambioMes(year, month);

                return Content(tipoCambioData.ToString(), "application/xml"); 
            }
            catch (Exception ex)
            {
                return Content("Error al obtener el tipo de cambio: " + ex.Message, "text/plain"); 
            }
        }

    }
}
