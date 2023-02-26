namespace DicePoker.Domain.Models
{
    public class OpponentHand
    {
        public int Id { get; set; }
        public string HandNumbers { get; set; }
        public int NumberOfThrows { get; set; }
        public bool IsComputer { get; set; }
    }
}