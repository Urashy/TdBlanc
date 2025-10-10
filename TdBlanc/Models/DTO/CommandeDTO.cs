namespace TdBlanc.Models.DTO
{
    public class CommandeDTO
    {
        public int IdCommande { get; set; }
        public String? NomArticle { get; set; }
        public double Montant { get; set; }
        public int? UtilisateurId { get; set; } 
        public string? UtilisateurNom { get; set; }
    }
}