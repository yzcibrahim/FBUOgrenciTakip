using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Ogrenci:BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tel { get; set; }

        public ICollection<Not> Nots { get; set; }
    }
}
