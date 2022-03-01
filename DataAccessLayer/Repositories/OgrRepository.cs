using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OgrRepository
    {
        OgrDbContext _ctx;
        public OgrRepository(OgrDbContext ctx)
        {
            _ctx = ctx;
        }

        public Ogrenci AddOrUpdate (Ogrenci ogr)
        {
            if(ogr.Id>0)
            {
                _ctx.Attach(ogr);
                _ctx.Entry(ogr).State = EntityState.Modified;
            }
            else
            {
                _ctx.Ogrenciler.Add(ogr);
            }
            _ctx.SaveChanges();

            return ogr;
        }

        public Ogrenci GetById(int id)
        {
           return _ctx.Ogrenciler.Include(c=>c.Nots).FirstOrDefault(c => c.Id==id);
        }

        public void Delete(int id)
        {
            Ogrenci silinecekOgrenci = GetById(id);
            _ctx.Ogrenciler.Remove(silinecekOgrenci);
            _ctx.SaveChanges();
        }

        public List<Ogrenci> List()
        {
            return _ctx.Ogrenciler.ToList();
        }


    }
}
