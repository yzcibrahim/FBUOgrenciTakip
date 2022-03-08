using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using FBUOgrenciTakip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBUOgrenciTakip.Controllers
{
    public class OgretmenController : Controller
    {
        IRepository<Ogretmen> _repository;
        public OgretmenController(IRepository<Ogretmen> repository)
        {
            _repository = repository;
        }
        // GET: OgretmenController
        public ActionResult Index()
        {
            List<Ogretmen> liste = _repository.List();

            List<OgretmenViewModel> model = new List<OgretmenViewModel>();

            foreach(var ogr in liste)
            {
                OgretmenViewModel ogrVm = new OgretmenViewModel();
                ogrVm.Id = ogr.Id;
                ogrVm.Ad = ogr.Ad;
                ogrVm.Soyad = ogr.Soyad;
                model.Add(ogrVm);
            }

            return View(model);
        }

        // GET: OgretmenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OgretmenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OgretmenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OgretmenController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(!id.HasValue || id.Value<=0)
            {
                return View(new OgretmenViewModel());
            }

            Ogretmen ogretmen = _repository.GetById(id.Value);
            
            OgretmenViewModel model = new OgretmenViewModel()
            {
                Id = ogretmen.Id,
                Ad = ogretmen.Ad,
                Soyad = ogretmen.Soyad
            };
            
            return View(model);
        }

        // POST: OgretmenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OgretmenViewModel model)
        {
            Ogretmen ogretmen = new Ogretmen() { Id = model.Id, Ad = model.Ad, Soyad = model.Soyad };
            _repository.AddOrUpdate(ogretmen);
            return RedirectToAction("Index");
        }

        // GET: OgretmenController/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
