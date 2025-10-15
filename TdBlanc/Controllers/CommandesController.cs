using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TdBlanc.Models;
using TdBlanc.Models.DTO;
using TdBlanc.Models.Repository;

namespace TdBlanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly CommandeManager _manager;
        private readonly IMapper _mapper;

        public CommandesController(CommandeManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        // GET: api/Commandes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CommandeDTO>>> GetCommandes()
        {
            var commandes = await _manager.GetAllAsync();
            var commandesDTO = _mapper.Map<IEnumerable<CommandeDTO>>(commandes);
            return Ok(commandesDTO);
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommandeDTO>> GetCommande(int id)
        {
            var commande = await _manager.GetByIdAsync(id);

            if (commande == null)
            {
                return NotFound();
            }

            var commandeDTO = _mapper.Map<CommandeDTO>(commande);
            return Ok(commandeDTO);
        }

        // GET: api/Commandes/article/NomArticle
        [HttpGet("article/{nomArticle}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommandeDTO>> GetCommandeByArticle(string nomArticle)
        {
            var commande = await _manager.GetByKeyAsync(nomArticle);

            if (commande == null)
            {
                return NotFound();
            }

            var commandeDTO = _mapper.Map<CommandeDTO>(commande);
            return Ok(commandeDTO);
        }

        // PUT: api/Commandes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCommande(int id, CommandeDTO commandeDTO)
        {
            if (id != commandeDTO.IdCommande)
            {
                return BadRequest("L'ID de la commande ne correspond pas.");
            }

            var commandeToUpdate = await _manager.GetByIdAsync(id);
            if (commandeToUpdate == null)
            {
                return NotFound();
            }

            var commande = _mapper.Map<Commande>(commandeDTO);
            await _manager.UpdateAsync(commandeToUpdate, commande);

            return NoContent();
        }

        // POST: api/Commandes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CommandeDTO>> PostCommande(CommandeDTO commandeDTO)
        {
            var commande = _mapper.Map<Commande>(commandeDTO);
            await _manager.AddAsync(commande);

            var createdCommandeDTO = _mapper.Map<CommandeDTO>(commande);
            return CreatedAtAction(nameof(GetCommande), new { id = commande.IdCommande }, createdCommandeDTO);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commande = await _manager.GetByIdAsync(id);
            if (commande == null)
            {
                return NotFound();
            }

            await _manager.DeleteAsync(commande);
            return NoContent();
        }
    }
}