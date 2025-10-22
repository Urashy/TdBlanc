using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TdBlanc.Models
{
    [Table("T_E_ANIMAL_ANI")]
    public class Animal
    {
        [Key]
        [Column("ANI_ID")]
        public int IdAnnimal { get; set; }

        [Column("ANI_NOM")]
        public string? Nom { get; set; }

        [Column("ANI_POID")]
        public double Poid { get; set; }

        [Column("ANI_REFERENCE")]
        public string? Reference { get; set; }

        [NotMapped]
        public bool IsPrivate { get; set; }

        [NotMapped]
        public string DisplayReference
        {
            get
            {
                var context = new Strategy.ReferenceContext();
                context.SetStrategy(IsPrivate
                    ? new Strategy.PrivateReferenceStrategy()
                    : new Strategy.NormalReferenceStrategy());
                return context.ApplyReference(Reference ?? "");
            }
        }
    }
}