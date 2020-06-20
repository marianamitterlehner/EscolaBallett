using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoAppService _contatoApp;

        public ContatoController(IContatoAppService contatoApp)
        {
            _contatoApp = contatoApp;
        }
        // GET: Contato
        public ActionResult Index()
        {
            var contatoViewModel = Mapper.Map<IEnumerable<Contato>, IEnumerable<ContatoViewModel>>(_contatoApp.GetAll());
            return View(contatoViewModel);
        }

        // GET: Contato/Details/5
        public ActionResult Details(int id)
        {
            var contato = Mapper.Map<Contato, ContatoViewModel>(_contatoApp.GetById(id));

            return View();
        }

        // GET: Contato/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        public ActionResult Create(ContatoViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var contato = Mapper.Map<ContatoViewModel, Contato>(viewModel);
                    _contatoApp.Add(contato);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
                return View();
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contato/Edit/5
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

        // GET: Contato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contato/Delete/5
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
