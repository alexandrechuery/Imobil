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
    public class ImovelController : BaseController
    {
        private ImovelBDEntities db = new ImovelBDEntities();

        public ActionResult Index()
        {
            var imoveis = db.Imovel.Include("Bairro").Include("Proprietario").Include("TipoImovel").ToList();
            return View(imoveis);
        }

        public ActionResult Inserir()
        {
            ViewBag.IdBairro = new SelectList(db.Bairro, "IdBairro", "NomeBairro");
            ViewBag.IdProprietario = new SelectList(db.Proprietario, "IdProprietario", "NomeProprietario");
            ViewBag.IdTipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "NomeTipoImovel");
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                db.Imovel.Add(imovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBairro = new SelectList(db.Bairro, "IdBairro", "NomeBairro");
            ViewBag.IdProprietario = new SelectList(db.Proprietario, "IdProprietario", "NomeProprietario");
            ViewBag.IdTipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "NomeTipoImovel");
            return View(imovel);
        }

        public ActionResult Alterar(int id)
        {
            Imovel imovel = db.Imovel.Find(id);
            ViewBag.IdBairro = new SelectList(db.Bairro, "IdBairro", "NomeBairro");
            ViewBag.IdProprietario = new SelectList(db.Proprietario, "IdProprietario", "NomeProprietario");
            ViewBag.IdTipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "NomeTipoImovel");
            return View(imovel);
        }

        [HttpPost]
        public ActionResult Alterar(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBairro = new SelectList(db.Bairro, "IdBairro", "NomeBairro");
            ViewBag.IdProprietario = new SelectList(db.Proprietario, "IdProprietario", "NomeProprietario");
            ViewBag.IdTipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "NomeTipoImovel");
            return View(imovel);
        }

        public ActionResult Excluir(int id)
        {
            Imovel imovel = db.Imovel.Find(id);
            ViewBag.IdBairro = new SelectList(db.Bairro, "IdBairro", "NomeBairro");
            ViewBag.IdProprietario = new SelectList(db.Proprietario, "IdProprietario", "NomeProprietario");
            ViewBag.IdTipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "NomeTipoImovel");
            return View(imovel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Imovel imovel = db.Imovel.Find(id);
                db.Imovel.Remove(imovel);
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
