using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class FlimRepository : IFlimRepository
    {
        public async Task<Result> createFlim(Result result)
        {
            using (var flimDB = new FlimsApiDbContext())
            {
                var newResult = new Result()
                {
                    id = result.id,
                    name = result.name,
                    original_name = result.original_name,
                    original_title = result.original_title,
                    title = result.title
                };

                flimDB.Results.Add(newResult);
                await flimDB.SaveChangesAsync();

                return newResult;
            }
        }


        public async Task deleteFlim(int id)
        {
            using (var flimDB = new FlimsApiDbContext())
            {

                var deletedflims = GetFlimsById(id);
                flimDB.Results.Remove(await deletedflims);
                await flimDB.SaveChangesAsync();
            }
        }

        public async Task<Result> GetFlimsById(int id)
        {
            using (var flimDB = new FlimsApiDbContext())
            {
                return await flimDB.Results.FindAsync(id);
            }
        }

        public async Task<Result> updateFlim(Result result)
        {
            using (var flimDB = new FlimsApiDbContext())
            {
                var newResult = new Result()
                {
                    id = result.id,
                    name = result.name,
                    original_name = result.original_name,
                    original_title = result.original_title,
                    title = result.title
                };

                flimDB.Results.Update(newResult);
                await flimDB.SaveChangesAsync();
                return newResult;
            }
        }
    }
}
