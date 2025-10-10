using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TdBlanc.Models;
using TdBlanc.Models.DTO;
using TdBlanc.Models.Repository;

namespace TdBlanc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Commande> _CommandeRepository;

        public CommandeController(
            IMapper mapper,
            IRepository<Commande> CommandeRepository)
        {
            _mapper = mapper;
            _CommandeRepository = CommandeRepository;
        }

        // GetAll retourne ProduitDTO
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<CommandeDTO>>> GetAll()
        {


            var entities = await _CommandeRepository.GetAllAsync();
            if (entities == null)
            {
                return NotFound();
            }
            var dtos = _mapper.Map<IEnumerable<CommandeDTO>>(entities);

            return Ok(dtos);


        }

        // GetById retourne ProduitDetailDTO
        [HttpGet("{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<Commande>> GetById(int id)
        {
            var entity = await _CommandeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<Commande>(entity);
            return Ok(dto);
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<ActionResult<Commande>> Add([FromBody] Commande entity)
        {
            await _CommandeRepository.AddAsync(entity);
            return CreatedAtAction("GetById", new { id = entity.IdCommande }, entity);
        }

        [HttpPut("{id}")]
        [ActionName("Update")]
        public async Task<ActionResult> Update(int id, [FromBody] Commande dto)
        {
            var entityToUpdate = await _CommandeRepository.GetByIdAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, entityToUpdate);
            await _CommandeRepository.UpdateAsync(entityToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var entity = await _CommandeRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }


                await _CommandeRepository.DeleteAsync(entity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur lors de la suppression du produit : {ex.Message}");
            }
        }

        
    }
}
