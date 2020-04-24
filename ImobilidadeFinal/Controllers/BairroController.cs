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
    public class BairroController : BaseController
    {
        private ImovelBDEntities db = new ImovelBDEntities();

        public ActionResult Index()
        {
            var bairros = db.Bairro.ToList();
            return View(bairros);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Bairro.Add(bairro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        public ActionResult Alterar(int id)
        {
            Bairro bairro = db.Bairro.Find(id);
            return View(bairro);
        }

        [HttpPost]
        public ActionResult Alterar(Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bairro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        public ActionResult Excluir(int id)
        {
            Bairro bairro = db.Bairro.Find(id);
            return View(bairro);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Bairro bairro = db.Bairro.Find(id);
                db.Bairro.Remove(bairro);
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
