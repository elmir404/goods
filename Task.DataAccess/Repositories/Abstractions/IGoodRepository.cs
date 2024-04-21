using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataAccess.Entities;

namespace Task.DataAccess.Repositories.Abstractions
{
    public interface IGoodRepository
    {
        Task<List<Goods_TNVED>> GetGoodsByCode(string code);
        Task<Goods_TNVED> GetGoodByCode(string code);
    }
}
