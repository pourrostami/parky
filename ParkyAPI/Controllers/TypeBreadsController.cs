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
    public class TypeBreadsController : ControllerBase
    {
        private ITypeBreadRepository _typeBreadRepository;
        private readonly IMapper _mapper;

        public TypeBreadsController(ITypeBreadRepository typeBreadRepository, IMapper mapper)
        {
            _typeBreadRepository = typeBreadRepository;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTypeBreads()
        {
            var typeBreads = await _typeBreadRepository.GetTypeBreads();
            List<TypeBreadDto> typeBreadDtos = new List<TypeBreadDto>();
            foreach (var item in typeBreads)
            {
                typeBreadDtos.Add(_mapper.Map<TypeBreadDto>(item));
            }
            return Ok(typeBreadDtos);
        }

        [HttpGet("[action]/{typeBreadId:int}")]
        public async Task<IActionResult> GetTypeBread(int typeBreadId)
        {
            TypeBread typeBread =await _typeBreadRepository.GetTypeBread(typeBreadId);

            if (typeBread == null)
                return NotFound();

            TypeBreadDto typeBreadDto = _mapper.Map<TypeBreadDto>(typeBread);

            return Ok(typeBreadDto);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTypeBread([FromBody] TypeBreadDto typeBreadDto)
        {
            if (typeBreadDto == null)
                return BadRequest(ModelState);

            if (await _typeBreadRepository.TypeBreadExists(typeBreadDto.Name))
            {
                ModelState.AddModelError("", "TypeBread Exist!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TypeBread typeBread = _mapper.Map<TypeBread>(typeBreadDto);

            if (!await _typeBreadRepository.CreateTypeBread(typeBread))
            {
                ModelState.AddModelError("", $"Somthing went wrong when saving the record {typeBread.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }


        [HttpPatch("[action]/{typeBreadId:int}")]
        public async Task<IActionResult> UpdateTypeBread(int typeBreadId, [FromBody] TypeBreadDto typeBreadDto)
        {
            if (typeBreadDto == null || typeBreadId != typeBreadDto.TypeBreadId)
                return BadRequest();

            TypeBread typeBread = _mapper.Map<TypeBread>(typeBreadDto);

            if (!await _typeBreadRepository.UpdateTypeBread(typeBread))
            {
                ModelState.AddModelError("", $"Somthing went wrong when updating the record {typeBread.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }



        [HttpDelete("[action]/{typeBreadId:int}")]
        public async Task<IActionResult> DeleteTypeBread(int typeBreadId)
        {
            if (!await _typeBreadRepository.TypeBreadExists(typeBreadId))
                return NotFound();

            TypeBread typeBread = await _typeBreadRepository.GetTypeBread(typeBreadId);

            if (!await _typeBreadRepository.DeleteTypeBread(typeBread))
            {
                ModelState.AddModelError("", $"Somthing went wrong when deleting the record {typeBread.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
