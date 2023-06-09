using Microsoft.AspNetCore.Mvc;
using Service.DTO_s.Model;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace API_Application.Controllers
{
    public class ModelController : AppController
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModelCreateDTO model)
        {
            await _modelService.Create(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _modelService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Detail([Required] int id)
        {
            return Ok(await _modelService.Get(id));
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Update([Required] int id, ModelUpdateDTO model)
        {
            try
            {
                await _modelService.Update(id, model);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _modelService.Delete(id);
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
                await _modelService.SoftDelete(id);
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
            return Ok(await _modelService.FindAll(search));
        }
    }
}
