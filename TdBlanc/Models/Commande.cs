using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TdBlanc.Models
{
    [Table("T_E_COMMANDE_COM")]
    public class Commande 
    {
        [Key]
        [Column("COM_ID")]
        public int IdCommande { get; set; }

        [Column("COM_NOMARTICLE")]
        public String? NomArticle { get; set; }

        [Column("COM_MONTANT")]
        public double Montant { get; set; }

    }
}