using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class ManufacturerDetail : ModelBase
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
