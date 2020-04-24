using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ImobilidadeFinal.Models;

namespace ImobilidadeFinal.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ProprietarioController : BaseController
    {
        private ImovelBDEntities db = new ImovelBDEntities();

        public ActionResult Index()
        {
            var proprietarios = db.Proprietario.ToList();
            return View(proprietarios);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Proprietario.Add(proprietario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprietario);
        }

        public ActionResult Alterar(int id)
        {
            Proprietario proprietario = db.Proprietario.Find(id);
            return View(proprietario);
        }

        [HttpPost]
        public ActionResult Alterar(Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprietario);
        }

        public ActionResult Excluir(int id)
        {
            Proprietario proprietario = db.Proprietario.Find(id);
            return View(proprietario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Proprietario proprietario = db.Proprietario.Find(id);
                db.Proprietario.Remove(proprietario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErroExcluir");
            }
        }

    }
}
