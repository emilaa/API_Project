using Microsoft.AspNetCore.Mvc;
using Service.DTO_s.Marka;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace API_Application.Controllers
{
    public class MarkaController : AppController
    {
        private readonly IMarkaService _markaService;

        public MarkaController(IMarkaService markaService)
        {
            _markaService = markaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MarkaCreateDTO marka)
        {
            await _markaService.Create(marka);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _markaService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Detail([Required] int id)
        {
            return Ok(await _markaService.Get(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _markaService.Delete(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete([Required] int id)
        {
            try
            {
                await _markaService.SoftDelete(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([Required] int id, MarkaUpdateDTO marka)
        {
            try
            {
                await _markaService.Update(id, marka);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? search)
        {
            return Ok(await _markaService.FindAll(search));
        }
    }
}
