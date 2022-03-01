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
    }
}
