using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaAppService _noticiaApp;

        public NoticiaController(INoticiaAppService noticiaApp)
        {
            _noticiaApp = noticiaApp;
        }
        // GET: Noticia
        public ActionResult Index()
        {
            var noticia = Mapper.Map<IEnumerable<Noticia>, IEnumerable<NoticiaViewModel>>(_noticiaApp.GetAll());
            return View(noticia);
        }
        // GET: Noticia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Noticia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Noticia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Noticia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Noticia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Noticia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Noticia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
