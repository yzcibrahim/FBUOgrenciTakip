using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Not
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        public int OgrId { get; set; }

        [ForeignKey("OgrId")]
        public Ogrenci Ogr { get; set; }
    }
}
