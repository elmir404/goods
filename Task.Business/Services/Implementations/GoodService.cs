using Task.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Business.Dtos;
using Task.Business.Services.Abstractions;
using Task.DataAccess.Entities;
using Task.DataAccess.Repositories.Abstractions;

namespace Task.Business.Services.Implementations
{
    internal class GoodService : IGoodtService
    {
        private readonly IGoodRepository _productRepository;

        public GoodService(IGoodRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResult> GetGoodsByCode(string code)
        {
            try
            {
                if (code.Length != 10)
                {
                    return new ServiceResult(false, "Kod parametri 10 rəqəmli olmalıdır!");
                }
                var parent = await _productRepository.GetGoodByCode(code);

                var result = await _productRepository.GetGoodsByCode(parent.CODE);
                List<GetGoodsDto> three = result
                   .Where(e => e.Id == parent.Id)
                   .Select(e => new GetGoodsDto
                   {
                       Id = e.Id,
                       name = e.Name,
                       Defis = e.DEFIS,
                       code = e.CODE,
                       parentId = e.PARENT_ID,
                       children = GetSubGoods(result, e.Id),
                   }).ToList();


                return new ServiceResult(true, three);
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }
        private static List<GetGoodsDto> GetSubGoods(List<Goods_TNVED> items, int parentId)
        {

            return items.Where(x => x.PARENT_ID == parentId)
                .Select(e => new GetGoodsDto
                {
                    Id = e.Id,
                    name = e.Name,
                    Defis = e.DEFIS,
                    code = e.CODE,
                    parentId = e.PARENT_ID,
                    children = GetSubGoods(items, e.Id),

                }).ToList();
        }



    }

}
