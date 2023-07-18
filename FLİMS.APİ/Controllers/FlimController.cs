using Businnes.Abstract;
using DataAccess;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Flim.APİ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlimController : ControllerBase
    {
        private readonly IFlimService FlimService;

        private readonly FlimsApiDbContext dbContext;

        public FlimController(IFlimService flimService, FlimsApiDbContext dbContext)
        {
            FlimService = flimService;
            this.dbContext = dbContext;
        }



        [HttpGet("Deneme/name{name}")]
        public async Task<IActionResult> Deneme(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound("YOK BOYLE BİRŞEY ALİ CABBAR");
            }
            List<Result> query = dbContext.Results.Where(c => c.title == name).ToList();

           //var results = await query.ToListAsync();

            if (query.Count == 0)
            {
                return NotFound("YOK BOYLE BİRŞEY ALİ CABBAR");
            }


          

            return Ok(query);
            }


        [HttpGet("Denemec/harf{kelime}")]
        public async Task<IActionResult> Denemec(string kelime)
        {
            if (string.IsNullOrWhiteSpace(kelime))
            {
                return NotFound("YOK BOYLE BİRŞEY ALİ CABBAR");
            }
            List<Result> query = dbContext.Results.Where(c => c.title.Contains(kelime)).ToList();

            //var results = await query.ToListAsync();

            if (query.Count == 0)
            {
                return NotFound("YOK BOYLE BİRŞEY ALİ CABBAR");
            }




            return Ok(query);
        }


        [HttpGet]
        [Route("{action}")]
        public async Task<IActionResult> List()
        {
            var dbContext = new FlimsApiDbContext();
            var db = dbContext.Results.ToList();
            return Ok(db);
        }
        [HttpGet]
        [Route("{action}")]
        public async Task<IActionResult> Get()
        {
          // FlimService nesnesini başlatın veya gerekli bağımlılıkları enjekte edin

            int resultCount = await FlimService.GetFlimsApi();

            var dbContext = new FlimsApiDbContext(); // dbContext nesnesini başlatın veya gerekli bağımlılıkları enjekte edin

            var results = dbContext.Results.ToList();

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

        [HttpPut]
        [Route("{action}/{id}")]
        public async Task<IActionResult> Put([FromBody] Result Result)
        {

            var ss = await FlimService.updateFlim(Result);

            return Ok(ss);
        }

        [HttpPost]  
        
        public async Task<IActionResult> Post([FromBody] Result Result )
        {
            var createdMovie =  await FlimService.createFlim(Result);
               return  CreatedAtAction("Get", new { id = createdMovie.id }, createdMovie);
        }

        [HttpDelete]
        [Route("{action}/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await FlimService.GetFlimsById(id) != null)
            {
                FlimService.deleteFlim(id);
                return Ok();
            }
            return NotFound();
        }

    }
}
