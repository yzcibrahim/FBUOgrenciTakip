using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBUOgrenciTakip.Controllers
{
    public class OgrenciController : Controller
    {
        OgrRepository _ogrRepository;
        public OgrenciController(OgrRepository ogrRepository)
        {
            _ogrRepository = ogrRepository;
        }
        public IActionResult Index()
        {
            List<Ogrenci> model = _ogrRepository.List();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string aranacak, string aranacakSoyad)
        {
            List<Ogrenci> model = _ogrRepository.List();
            if (!String.IsNullOrEmpty(aranacak))
            {
                model = model.Where(c => c.Ad.ToUpper() == aranacak.ToUpper()).ToList();
            }

            if (!String.IsNullOrEmpty(aranacakSoyad))
            {
                model = model.Where(c => c.Soyad.ToUpper().StartsWith(aranacakSoyad.ToUpper())).ToList();
            }
            ViewBag.aranacak = aranacak;
            ViewBag.aranacakSoyad = aranacakSoyad;

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ogrenci ogr)
        {
            _ogrRepository.AddOrUpdate(ogr);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Ogrenci ogr = _ogrRepository.GetById(id);
            return View(ogr);
        }
        [HttpPost]
        public IActionResult Edit(Ogrenci ogr)
        {
            _ogrRepository.AddOrUpdate(ogr);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _ogrRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
