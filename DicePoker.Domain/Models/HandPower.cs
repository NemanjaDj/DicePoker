using DicePoker.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DicePoker.Domain.Models
{
    public class HandPower
    {
        [Key]
        public int Id { get; set; }
        public int? HandId { get; set; }
        public int? OpponentHandId { get; set; }
        public HandPowerType handPowerType { get; set; }
        public int LeadNumber { get; set; }
        public int FollowingNumber { get; set; }
    }
}
