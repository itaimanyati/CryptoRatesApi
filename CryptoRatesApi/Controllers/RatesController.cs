using System;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Interfaces;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoRatesApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
   //[Authorize]
    public class RatesController : Controller
    {
        
        private IUnitOfWork _unitOfWork;
      
        public RatesController(IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
          
        }

        [HttpGet]
        public IEnumerable<Rate> Get()
        {
            return _unitOfWork.Rates.GetAll();
            
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var rate = _unitOfWork.Rates.Get(id);
            if (rate == null)
                return NotFound("Rate with given id in not found");

            return Ok(rate);
        }

      
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                var data = CMC_Service.GetCMCRates().Result;

                
                foreach (var item in data)
                {
                    var rate = new Rate()
                    {
                        id = item.id,
                        name = item.name,
                        symbol = item.symbol,
                        slug = item.slug,
                        price = item.quote.USD.price,
                        percentage_change_24h = item.quote.USD.percent_change_24h,
                        percentage_change_7d = item.quote.USD.percent_change_7d,
                        market_cap = item.quote.USD.market_cap,
                        circulating_supply = item.circulating_supply

                    };

                    _unitOfWork.Rates.Create(rate);
                }

                


                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPut]
        public ActionResult Put([FromBody] Rate rate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.Rates.Update(rate);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            // Find if rate exists before attempting to delete
            var rateObj = _unitOfWork.Rates.Get(id);

            // If it exists, abort and notify failed delete reason
            if (rateObj == null)
                return NotFound("Specified can't be deleted because it doesn't exist");

            //If exists proceed with deletion
            _unitOfWork.Rates.Remove(rateObj);
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
