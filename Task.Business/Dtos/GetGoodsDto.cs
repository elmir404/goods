using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataAccess.Entities;

namespace Task.Business.Dtos
{
    public class GetGoodsDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string Defis { get; set; }
        public int? parentId { get; set; }

        public ICollection<GetGoodsDto> children { get; set; }
    }
}
