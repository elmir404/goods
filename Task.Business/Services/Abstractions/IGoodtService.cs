using Education.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Business.Services.Abstractions
{
    public interface IGoodtService
    {
        Task<ServiceResult> GetGoodsByCode(string code);
    }
}
