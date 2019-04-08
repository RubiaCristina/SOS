using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOS_MoradoresDeRua.Controllers
{
    public class ErroController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NaoEncontrado()
        {
            return View();
        }
    }
}