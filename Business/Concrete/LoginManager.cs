using Businnes.Abstract;
using DataAccess.Concrete;  
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

using Newtonsoft.Json;
using DataAccess;
using DataAccess.Abstract;

namespace Businnes.Concrete
{
    public class LoginManager : IFlimService
    {

        private readonly FlimsApiDbContext _dbContext;

        private readonly IFlimRepository _FlimRepository;

        public LoginManager(FlimsApiDbContext dbContext, IFlimRepository flimRepository)
        {
            _dbContext = dbContext;
            _FlimRepository = flimRepository;
        }

        public async Task<Result> createFlim(Result result)
        {
            return await _FlimRepository.createFlim(result);
        }

        public async Task deleteFlim(int id)
        {
             await _FlimRepository.deleteFlim(id);
        }

      
        public async Task<Result> GetFlimsById(int id)
        {
            return await _FlimRepository.GetFlimsById(id);
        }

        public async Task<Result> updateFlim(Result result)
        {
            return await _FlimRepository.updateFlim(result);

        }

        async Task<int> IFlimService.GetFlimsApi()
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/trending/all/day?language=en-US");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZTU4NWZlYzVhNTY2MmUwMDI4ZWRiYWU4ZDg5YWY5OSIsInN1YiI6IjYzOGYzNTQxNTgwMGM0MDBhNWRjOGFiMCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.VWsrG2UpOM1Ofh-Tq6HcHRQZtj_x00mpWDwd1M6E8As");
            var response = await client.GetAsync(request);

            var login = JsonConvert.DeserializeObject<Rootobject>(response.Content);
            var results = login.results;
            var resultss = login;
            foreach (var result in results)
            {
                if (!string.IsNullOrEmpty(result.release_date))
                {
                    _dbContext.Results.Add(result);
                }

             
            }
            var resultCount =  await _dbContext.SaveChangesAsync();

            return resultCount;
        }
    }
}
