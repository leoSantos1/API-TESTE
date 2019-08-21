using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Configuration.Controllers
{
    public class ConfigurationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View(new Logic.Configuration().Get());
        }

        // Por enquanto aqui só irá trabalhar com 1 registro
        [HttpPost]
        public ActionResult EditConfig(Model.Configuration pModel)
        {
            try
            {
                new Logic.Configuration().Update(pModel);
            }
            catch (Exception ex)
            {
                ViewBag.erro = ex.Message;
                return View("Index", ViewBag.erro);
            }
            return View("Index", pModel);
        }


        [HttpPost]
        public ActionResult Create(Model.Configuration pModel)
        {
            try
            {
                new Logic.Configuration().Add(pModel);
            }
            catch(Exception ex)
            {
                ViewBag.erro = ex.Message;
                return View("Index", ViewBag.erro);
            }
            return View("Index", pModel);
        }
    }
}