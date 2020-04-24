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
    public class TipoNegocioController : BaseController
    {
        private ImovelBDEntities db = new ImovelBDEntities();

        // GET: TipoNegocio
        public ActionResult Index()
        {
            var tiposNegocios = db.TipoNegocio.ToList();
            return View(tiposNegocios);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(TipoNegocio tipoNegocio)
        {
            if (ModelState.IsValid)
            {
                db.TipoNegocio.Add(tipoNegocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoNegocio);
        }

        public ActionResult Alterar(int id)
        {
            TipoNegocio tipoNegocio = db.TipoNegocio.Find(id);
            return View(tipoNegocio);
        }

        [HttpPost]
        public ActionResult Alterar(TipoNegocio tipoNegocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoNegocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoNegocio);
        }

        public ActionResult Excluir(int id)
        {
            TipoNegocio tipoNegocio = db.TipoNegocio.Find(id);
            return View(tipoNegocio);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                TipoNegocio tipoNegocio = db.TipoNegocio.Find(id);
                db.TipoNegocio.Remove(tipoNegocio);
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
