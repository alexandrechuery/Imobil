using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImobilidadeFinal.Models;

namespace ImobilidadeFinal.Controllers
{
    public class NegocioController : BaseController
    {
        private ImovelBDEntities db = new ImovelBDEntities();

        public ActionResult Index()
        {
            var negocios = db.Negocio.Include("Imovel").Include("TipoNegocio").ToList();
            return View(negocios);
        }

        public ActionResult Inserir()
        {
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "IdImovel");
            ViewBag.IdTipoNegocio = new SelectList(db.TipoNegocio, "IdTipoNegocio", "NomeTipoNegocio");
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Negocio.Add(negocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "IdImovel");
            ViewBag.IdTipoNegocio = new SelectList(db.TipoNegocio, "IdTipoNegocio", "NomeTipoNegocio");
            return View(negocio);
        }

        public ActionResult Alterar(int? id, int? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocio.Find(id, id2);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "IdImovel", negocio.IdImovel);
            ViewBag.IdTipoNegocio = new SelectList(db.TipoNegocio, "IdTipoNegocio", "NomeTipoNegocio", negocio.IdTipoNegocio);
            return View(negocio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar([Bind(Include = "IdNegocio,NomeNegocio,IdImovel,IdTipoNegocio")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(negocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "IdImovel", negocio.IdImovel);
            ViewBag.IdTipoNegocio = new SelectList(db.TipoNegocio, "IdTipoNegocio", "NomeTipoNegocio", negocio.IdTipoNegocio);
            return View(negocio);
        }

        public ActionResult Excluir(int? id, int? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocio.Find(id, id2);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ErroExcluir(int id, int id2)
        {
            try
            {
                Negocio negocio = db.Negocio.Find(id, id2);
                db.Negocio.Remove(negocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErroExcluir");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        

    }
}
