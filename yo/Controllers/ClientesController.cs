using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//IMPORTAR
using yo.Models;

namespace yo.Controllers
{
    public class ClientesController : Controller
    {
        ClientesDAO objDAO = new ClientesDAO();

        // GET: Clientes
        public ActionResult Ordenes_Cliente()
        {
            return View();
        }
        public  JsonResult ordenes_Por_Cliente(string codigo)
        {
            return Json(objDAO.OrdenesPorCliente(codigo),JsonRequestBehavior.AllowGet);
        }

        public JsonResult lista_Cliente()
        {
            return Json(objDAO.ListarClientes(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ordenes_Fecha()
        {
            return View();
        }

        public JsonResult ordenes_Por_Fecha(string fecha="01/03/2018")
        {
            DateTime xfecha = DateTime.Parse(fecha);

            return Json(objDAO.OrdenesPorFecha(xfecha),JsonRequestBehavior.AllowGet);
        }

    }
}