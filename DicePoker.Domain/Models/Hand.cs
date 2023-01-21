using System.ComponentModel.DataAnnotations;

namespace DicePoker.Domain.Models
{
    public class Hand
    {
        [Key]
        public int Id { get; set; }
        public string Numbers { get; set; }
        public bool IsActive { get; set; }
        public int NumberOfThrows { get; set; }
        public int PowerOfHand { get; set; }
    }
}
