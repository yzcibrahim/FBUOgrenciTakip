using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using FBUFirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBUFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrController : ControllerBase
    {
        OgrRepository _ogrenciRepository;
        public OgrController(OgrRepository ogrenciRepository)
        {
            _ogrenciRepository = ogrenciRepository;
        }
        // GET: api/<OgrController>
        [HttpGet]
        public IEnumerable<Ogrenci> Get()
        {

            return _ogrenciRepository.List();
        }

        // GET api/<OgrController>/5
        [HttpGet("{id}")]
        public OgrenciDto Get(int id)
        {
            OgrenciDto result = new OgrenciDto();

           // Thread.Sleep(5000);

            Ogrenci ogr = _ogrenciRepository.GetById(id);
            if (ogr == null)
            {
                result.Success = false;
                result.ErrorMessage = "Kayıt Bulunamadı";
                return result;
            }
            result.Success = true;
            result.Id = ogr.Id;
            result.Ad = ogr.Ad;
            result.Tel = ogr.Tel;
            result.Soyad = ogr.Soyad;
            return result;
        }

        // POST api/<OgrController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OgrController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OgrController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
