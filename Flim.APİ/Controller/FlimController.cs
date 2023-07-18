using Businnes.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flim.APİ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlimController : ControllerBase
    {
        private readonly IFlimService FlimService;

        private readonly FlimsApiDbContext dbContext;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultCount = await FlimService.GetFlimsApi(); // loginService.GetFlimsApi() metodu bir int değeri döndürüyor, bu yüzden doğru bir şekilde resultCount değişkenine atayabilirsiniz

            var results = dbContext.Results.ToList(); // Veritabanındaki tüm sonuçları al

            return Ok(results);
        }


        [HttpGet]
        [Route("{action}/{id}")]
        public async Task<IActionResult> GetFlimsByID(int id)
        {

            var ss = await FlimService.GetFlimsById(id);
            if (ss == null)
            {
                return NotFound();
            }

            return Ok(ss);
        }
    }
}
