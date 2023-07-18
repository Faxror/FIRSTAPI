using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccess.Abstract
{
    public interface IFlimRepository
    {
        Task<Result> GetFlimsById(int id);
        Task<Result> createFlim(Result result);
        Task<Result> updateFlim(Result result);

        Task deleteFlim(int id);
    }
}
