using System;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Interfaces;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoRates.Services.Interfaces;

namespace CryptoRatesApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
   //[Authorize]
    public class RatesController : Controller
    {
        
        private IUnitOfWork _unitOfWork;
        private readonly ICMC_Service _service;
      
        public RatesController(IUnitOfWork unitOfWork, ICMC_Service service)
        {
           
            _unitOfWork = unitOfWork;
            _service = service;
          
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
                return NotFound("Rate with given id is not found");

            return Ok(rate);
        }

      
        [HttpPost]
        public IActionResult Post()
        {

            var rate = _unitOfWork.Rates.StoreRates();
          
             return Ok();

             
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
            var ratesObj = await _service.GetCMCRates();
            if (ratesObj == null)
            {
                return NotFound();
            }

          return Ok(ratesObj);
        } 
    }
}
