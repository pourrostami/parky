using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;
using ParkyAPI.Repository.IRepository;

namespace ParkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreadsController : ControllerBase
    {
        private IBreadRepository _breadRepository;
        private readonly IMapper _mapper;

        public BreadsController(IBreadRepository breadRepository,IMapper mapper)
        {
            _breadRepository = breadRepository;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        //[HttpGet]
        public async Task<IActionResult> GetBreads()
        {
            var breads =await _breadRepository.GetBreads();
            List<BreadDto> breadDtos = new List<BreadDto>();
            foreach (var item in breads)
            {
                breadDtos.Add(_mapper.Map<BreadDto>(item));
            }
            return Ok(breadDtos);
        }


        /// <summary>
        /// Get Individual Bread
        /// </summary>
        /// <param name="breadId">The Id of the Bread</param>
        /// <param name="breadDto"></param>
        /// <returns></returns>
        [HttpGet("[action]/{breadId:int}")]
        public async Task<IActionResult> GetBread(int breadId)
        {
            Bread bread =await _breadRepository.GetBread(breadId);

            if (bread == null)
                return NotFound();

            BreadDto breadDto;

            breadDto = _mapper.Map<BreadDto>(bread);

            return Ok(breadDto);

        }

        /// <summary>
        /// Get List of Breads
        /// </summary>
        /// <param name="breadDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBread([FromBody] BreadDto breadDto)
        {
            if (breadDto == null)
                return BadRequest(ModelState);

            if (await _breadRepository.BreadExists(breadDto.Name))
            {
                ModelState.AddModelError("", "Bread Exist!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Bread bread = _mapper.Map<Bread>(breadDto);

            if (!await _breadRepository.CreateBread(bread))
            {
                ModelState.AddModelError("", $"Somthing went wrong when saving the record {bread.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }


        [HttpPatch("[action]/{breadId:int}")]
        public async Task<IActionResult> UpdateBread(int breadId, [FromBody] BreadDto breadDto)
        {
            if (breadDto == null || breadId != breadDto.BreadId)
                return BadRequest();

            Bread bread = _mapper.Map<Bread>(breadDto);

            if (! await _breadRepository.UpdateBread(bread))
            {
                ModelState.AddModelError("", $"Somthing went wrong when updating the record {bread.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


        [HttpDelete("[action]/{breadId:int}")]
        public async Task<IActionResult> DeleteBread(int breadId)
        {
            if (!await _breadRepository.BreadExists(breadId))
                return NotFound();

            Bread bread = await _breadRepository.GetBread(breadId);

            if (!await _breadRepository.DeleteBread(bread))
            {
                ModelState.AddModelError("", $"Somthing went wrong when deleting the record {bread.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
