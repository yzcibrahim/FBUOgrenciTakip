using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class NotRepository
    {
        OgrDbContext _ctx;
        public NotRepository(OgrDbContext ctx)
        {
            _ctx = ctx;
        }

        public Not AddOrUpdate (Not not)
        {
            if(not.Id>0)
            {
                _ctx.Attach(not);
                _ctx.Entry(not).State = EntityState.Modified;
            }
            else
            {
                _ctx.Notlar.Add(not);
            }
            _ctx.SaveChanges();

            return not;
        }

        public Not GetById(int id)
        {
           return _ctx.Notlar.FirstOrDefault(c => c.Id==id);
        }

        public void Delete(int id)
        {
            Not silinecekNot = GetById(id);
            _ctx.Notlar.Remove(silinecekNot);
            _ctx.SaveChanges();
        }

        public List<Not> List()
        {
            return _ctx.Notlar.ToList();
        }

        public List<Not> ListByOgrId(int ogrId)
        {
            return _ctx.Notlar.Where(c => c.OgrId == ogrId).ToList();
        }


    }
}
