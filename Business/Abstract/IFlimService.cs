    using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Businnes.Abstract
{
    public interface IFlimService
    {
        Task<Result> GetFlimsById(int id);
        Task<Result> createFlim(Result result);
        Task<Result> updateFlim(Result result);

        Task deleteFlim(int id);

        Task<int> GetFlimsApi();


    }
}
