namespace Front.ViewModels
{
    public class AnimalViewModel
    {
        public int IdAnimal { get; set; }
        public string? Nom { get; set; }
        public double Poid { get; set; }
        public string? Reference { get; set; }
        public bool IsPrivate { get; set; }
        public string? DisplayReference { get; set; }
    }
}
