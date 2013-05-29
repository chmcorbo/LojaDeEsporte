using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;

namespace LojaDeEsporte.Presentation.WebApp.Controllers
{
    //[Authorize(Users = "AdminCategoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        //
        // GET: /Categoria/
        [OutputCache(Duration = 3600, VaryByParam = "none", VaryByCustom = "language")]
        public ActionResult Index()
        {
            return View(_categoriaRepository.Categorias);
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Categoria categoria)
        {
            _categoriaRepository.Adicionar(categoria);
            return RedirectToAction("Index");
        }


        public ActionResult ChangeCulture(string language, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(language);
            return Redirect(returnUrl);
        }


    }
}