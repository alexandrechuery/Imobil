using ImobilidadeFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImobilidadeFinal.Controllers
{
    public class HomeController : Controller
    {
        private ImovelBDEntities db = new ImovelBDEntities();

        public ActionResult Index()
        {
            ViewBag.Negocio = new SelectList(db.Negocio, "IdImovel", "IdTipoNegocio", "Valor");
            ViewBag.Bairro = new SelectList(db.Bairro, "IdBairro", "NomeBairro");
            ViewBag.TipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "NomeTipoImovel");
            return View();
        }

        public ActionResult Pesquisar(Pesquisa pesquisa)
        {
            var imoveis = from r in db.Imovel
                          where r.IdBairro == pesquisa.IdBairro && r.IdImovel == pesquisa.IdImovel
                          select new ResultadoPesquisa
                          {
                              ValorTotal = r.ValorTotal,
                              Area = r.Area,
                              Quartos = r.Quartos,
                              Vagas = r.Vagas,
                              Suite = r.Suite
                          };
            return Json(imoveis, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PesquisarNegocioOuBairro(Pesquisa pesquisa)
        {
            var imoveis = from r in db.Imovel
                          where r.IdBairro == pesquisa.IdBairro || r.IdImovel == pesquisa.IdImovel
                          select new ResultadoPesquisa
                          {
                              ValorTotal = r.ValorTotal,
                              Area = r.Area,
                              Quartos = r.Quartos,
                              Vagas = r.Vagas,
                              Suite = r.Suite
                          };
            return Json(imoveis, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PesquisarImoveis(PesquisaImovel pesquisaImovel)
        {
            var imoveis = from r in db.Imovel
                          where r.IdTipoImovel == pesquisaImovel.IdTipoImovel
                          select new ResultadoPesquisaImovel
                          {
                              ValorTotal = r.ValorTotal,
                              Area = r.Area,
                              Quartos = r.Quartos,
                              Vagas = r.Vagas,
                              Suite = r.Suite
                          };
            return Json(imoveis, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Autenticação";
            return View();
        }
    }
}