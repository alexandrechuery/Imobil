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
    public class TipoImovelController : BaseController
    {
        private ImovelBDEntities db = new ImovelBDEntities();

        // GET: TipoImovel
        public ActionResult Index()
        {
            var tiposImoveis = db.TipoImovel.ToList();
            return View(tiposImoveis);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(TipoImovel tipoImovel)
        {
            if (ModelState.IsValid)
            {
                db.TipoImovel.Add(tipoImovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoImovel);
        }

        public ActionResult Alterar(int id)
        {
            TipoImovel tipoImovel = db.TipoImovel.Find(id);
            return View(tipoImovel);
        }

        [HttpPost]
        public ActionResult Alterar(TipoImovel tipoImovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoImovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoImovel);
        }

        public ActionResult Excluir(int id)
        {
            TipoImovel tipoImovel = db.TipoImovel.Find(id);
            return View(tipoImovel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                TipoImovel tipoImovel = db.TipoImovel.Find(id);
                db.TipoImovel.Remove(tipoImovel);
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
