using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataAccess.Entities;
using Task.DataAccess.Repositories.Abstractions;

namespace Task.DataAccess.Repositories.Implementations
{
    public class GoodRepository : IGoodRepository
    {
        private readonly string _connectionString;

        public GoodRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DictionariesDbConnection");
        }
        public async Task<List<Goods_TNVED>> GetGoodsByCode(string code)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                IEnumerable<Goods_TNVED> goodts = new List<Goods_TNVED>();
                string query = @"
                    WITH RecursiveCTE AS (
                        SELECT Id, Code, Defis, Name, Parent_id
                        FROM Goods_TNVED
                        WHERE Code = @Code

                        UNION ALL

                        SELECT g.Id, g.Code, g.Defis, g.Name, g.Parent_id
                        FROM Goods_TNVED g
                        INNER JOIN RecursiveCTE r ON g.Parent_id = r.Id
                    )
                    SELECT Id, Code, Defis, Name, Parent_id
                    FROM RecursiveCTE";
                goodts = await db.QueryAsync<Goods_TNVED>(query, new { Code = code });
                var goos = goodts.ToList();


                return goos;
            }



        }

        public async Task<Goods_TNVED> GetGoodByCode(string code)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT Id, Code, Defis, Name, Parent_id
                    FROM Goods_TNVED WHERE Code = @Code";
                var result = await db.QueryFirstOrDefaultAsync<Goods_TNVED>(query, new { Code = code });
                var resul1 = await GetGoodParent(result.Id);
                while (resul1.PARENT_ID != 0)
                {
                    resul1 = await GetGoodParent(resul1.PARENT_ID);
                }
                return resul1;
            }
        }
        private static async Task<Goods_TNVED> GetGoodParent(int id)
        {
            using (IDbConnection db = new SqlConnection("Server=DESKTOP-BOCAUO6;Database=Dictionaries;Trusted_Connection=True;"))
            {
                string query = @"
                    SELECT Id, Code, Defis, Name, Parent_id
                    FROM Goods_TNVED WHERE Id = @id";
                var result = await db.QueryFirstOrDefaultAsync<Goods_TNVED>(query, new { Id = id });
                return result;


            }
        }

    }
}
