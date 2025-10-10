using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text.Json.Serialization;
using TdBlanc.Models.Repository;

namespace TdBlanc.Models
{
    [Table("T_E_UTILISATEUR_UTI")]
    public class Utilisateur : IEntity, INamedEntity
    {
        [Key]
        [Column("UTI_ID")]
        public int IdUtilisateur { get; set; }

        [Column("UTI_NOM")]
        public String? Nom { get; set; }

        [Column("UTI_PRENOM")]
        public String? Prenom { get; set; }

        [Column("UTI_NUMERORUE")]
        [StringLength(10)]
        public string? NumeroRue { get; set; }

        [Column("UTI_RUE")]
        public string? Rue { get; set; }

        [Column("UTI_CODEPOSTAL")]
        [StringLength(5)]
        public int CodePostal { get; set; }

        [Column("UTI_VILLE")]
        public String? Ville { get; set; } = "Annecy";

        [InverseProperty(nameof(Commande.CommandeUtlisateurNavigation))]
        [JsonIgnore] // Évite la sérialisation circulaire
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        public int Id => IdUtilisateur;
    }
}
