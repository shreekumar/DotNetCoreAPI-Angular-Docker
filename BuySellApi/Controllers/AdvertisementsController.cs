using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuySellApi.Core;
using BuySellApi.Data;
using System;

namespace BuySellApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IAdvertisement _advertisement;

        public AdvertisementsController(IAdvertisement context)
        {
            _advertisement = context;
        }

        // GET: api/Advertisements
        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<Advertisement>>> FindAll()
        {
            try
            {
                var advertisements = await _advertisement.FindAll();
                return Ok(advertisements);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Advertisement>> Find(int id)
        {
            try
            {
                var advertisement = await _advertisement.Find(id);
                if (advertisement == null)
                {
                    return NotFound();
                }
                return Ok(advertisement);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Advertisements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Advertisement advertisement)
        {
            try
            {
                if (id != advertisement.Id)
                {
                    return BadRequest("Invalid model object");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _advertisement.Edit(advertisement);
                await _advertisement.Commit();

                return Ok(advertisement);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Advertisements
        [HttpPost]
        public async Task<ActionResult<Advertisement>> Create(Advertisement advertisement)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _advertisement.Create(advertisement);
                await _advertisement.Commit();

                return Ok(advertisement);
                //return CreatedAtAction("GetAdvertisement", new { id = advertisement.Id }, advertisement);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal server error: - " + e.InnerException.Message);
            }
        }

        // DELETE: api/Advertisements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Advertisement>> Delete(int id)
        {
            var advertisement = await _advertisement.Find(id);
            if (advertisement == null)
            {
                return NotFound();
            }

            _advertisement.Delete(advertisement);
            await _advertisement.Commit();

            return advertisement;
        }
    }
}
