﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? OgretmenId { get; set; }
        public ICollection<Not> Nots { get; set; }

        [ForeignKey("OgretmenId")]
        public virtual Ogretmen Ogretmen { get; set; }
    }
}
