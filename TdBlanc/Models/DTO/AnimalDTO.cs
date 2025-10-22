namespace TdBlanc.Models.DTO
{
    public class AnimalDTO
    {
        public int IdAnimal { get; set; }
        public String? Nom { get; set; }
        public double Poid { get; set; }
        public string? Reference { get; set; }
        public bool IsPrivate { get; set; }
        public string? DisplayReference { get; set; }
    }
}
