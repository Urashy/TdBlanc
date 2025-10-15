namespace TdBlanc.Models.DTO
{
    public class UtilisateurDTO
    {
        public int IdUtilisateur { get; set; }
        public String? Nom { get; set; }
        public String? Prenom { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    }
}
