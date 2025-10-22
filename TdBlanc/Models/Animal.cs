using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TdBlanc.Models
{
    [Table("T_E_ANNIMAL_ANI")]
    public class Animal
    {
        [Key]
        [Column("ANI_ID")]
        public int IdAnnimal { get; set; }

        [Column("ANI_NOM")]
        public String? Nom { get; set; }

        [Column("ANI_POID")]
        public double Poid { get; set; }
    }
}
    