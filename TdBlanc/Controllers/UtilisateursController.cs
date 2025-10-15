using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TdBlanc.Models;
using TdBlanc.Models.DTO;
using TdBlanc.Models.Repository;

namespace TdBlanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly UtilisateurManager _manager;
        private readonly IMapper _mapper;

        public UtilisateursController(UtilisateurManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UtilisateurDTO>>> GetUtilisateurs()
        {
            var utilisateurs = await _manager.GetAllAsync();
            var utilisateursDTO = _mapper.Map<IEnumerable<UtilisateurDTO>>(utilisateurs);
            return Ok(utilisateursDTO);
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UtilisateurDTO>> GetUtilisateur(int id)
        {
            var utilisateur = await _manager.GetByIdAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            var utilisateurDTO = _mapper.Map<UtilisateurDTO>(utilisateur);
            return Ok(utilisateurDTO);
        }

        // GET: api/Utilisateurs/nom/Dupont
        [HttpGet("nom/{nom}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UtilisateurDTO>> GetUtilisateurByNom(string nom)
        {
            var utilisateur = await _manager.GetByKeyAsync(nom);

            if (utilisateur == null)
            {
                return NotFound();
            }

            var utilisateurDTO = _mapper.Map<UtilisateurDTO>(utilisateur);
            return Ok(utilisateurDTO);
        }

        // PUT: api/Utilisateurs/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUtilisateur(int id, UtilisateurDTO utilisateurDTO)
        {
            if (id != utilisateurDTO.IdUtilisateur)
            {
                return BadRequest("L'ID de l'utilisateur ne correspond pas.");
            }

            var utilisateurToUpdate = await _manager.GetByIdAsync(id);
            if (utilisateurToUpdate == null)
            {
                return NotFound();
            }

            var utilisateur = _mapper.Map<Utilisateur>(utilisateurDTO);
            await _manager.UpdateAsync(utilisateurToUpdate, utilisateur);

            return NoContent();
        }

        // POST: api/Utilisateurs
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UtilisateurDTO>> PostUtilisateur(UtilisateurDTO utilisateurDTO)
        {
            var utilisateur = _mapper.Map<Utilisateur>(utilisateurDTO);
            await _manager.AddAsync(utilisateur);

            var createdUtilisateurDTO = _mapper.Map<UtilisateurDTO>(utilisateur);
            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.IdUtilisateur }, createdUtilisateurDTO);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await _manager.GetByIdAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            await _manager.DeleteAsync(utilisateur);
            return NoContent();
        }
    }
}