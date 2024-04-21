using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DataAccess.Entities
{
    public class Goods_TNVED
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CODE { get; set; }
        public string DEFIS { get; set; }
        public int? PARENT_ID { get; set; }

        public ICollection<Goods_TNVED> Goods_TNVEDs { get; set; }
    }
}
