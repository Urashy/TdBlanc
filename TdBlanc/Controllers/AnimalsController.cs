using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TdBlanc.Models;
using TdBlanc.Models.DTO;
using TdBlanc.Models.Repository;

namespace TdBlanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalManager _manager;
        private readonly IMapper _mapper;

        public AnimalsController(AnimalManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetAnimaux()
        {
            var animals = await _manager.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AnimalDTO>>(animals));
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDTO>> GetAnimal(int id)
        {
            var animal = await _manager.GetByIdAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AnimalDTO>(animal));
        }

        // PUT: api/Animals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, AnimalDTO animalDTO)
        {
            var existingAnimal = await _manager.GetByIdAsync(id);

            if (existingAnimal == null)
            {
                return NotFound();
            }

            var animal = _mapper.Map<Animal>(animalDTO);
            await _manager.UpdateAsync(existingAnimal, animal);

            return NoContent();
        }

        // POST: api/Animals
        [HttpPost]
        public async Task<ActionResult<AnimalDTO>> PostAnimal(AnimalDTO animalDTO)
        {
            var animal = _mapper.Map<Animal>(animalDTO);
            await _manager.AddAsync(animal);

            var resultDTO = _mapper.Map<AnimalDTO>(animal);
            return CreatedAtAction("GetAnimal", new { id = animal.IdAnimal }, resultDTO);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _manager.GetByIdAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            await _manager.DeleteAsync(animal);
            return NoContent();
        }
    }
}