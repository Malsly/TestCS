using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ShipmentRegistration : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Organisation { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String Manager { get; set; }
        public int Count { get; set; }
        public float Summa { get; set; }
    }
}
