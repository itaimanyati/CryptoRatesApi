using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoRatesApi.Controllers
{
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : Controller
    {
        private IRate _rateRepository;

        public RatesController(IRate rateRepository)
        {
            _rateRepository = rateRepository;
        }

        [HttpGet]
        public IEnumerable<Rate> Get()
        {
            return _rateRepository.GetRates();
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var rate = _rateRepository.GetRate(id);
            if (rate == null)
                return NotFound("Rate with given id in not found");

            return Ok(rate);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Rate rate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _rateRepository.AddRate(rate);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Rate rate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _rateRepository.UpdateRate(rate);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {

            // Find if rate exists before attempting to delete
            var rateObj = _rateRepository.GetRate(id);

            // If it exists, abort and notify failed delete reason
            if (rateObj == null)
                return NotFound("Specified can't be deleted because it doesn't exist");

            //If exists proceed with deletion
            _rateRepository.DeleteRate(id);
            return NoContent();
        }

        [HttpGet("[action]")]

        public async Task<ActionResult> Get_CMC_Rates()
        {
            var ratesObj = await CMC_Service.GetCMCRates();
            if (ratesObj == null)
            {
                return NotFound();
            }

          
            return Ok(ratesObj);
        } 
    }
}
