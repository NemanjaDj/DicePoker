using DicePoker.Domain.Models;

namespace DicePoker.Data.Interfaces
{
    public interface IHandPowerRepository
    {
        void SaveHandPower(HandPower handPower);
    }
}
