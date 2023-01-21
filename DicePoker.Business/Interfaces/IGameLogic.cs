using DicePoker.Domain.Models;
using System.Collections.Generic;

namespace DicePoker.Business.Interfaces
{
    public interface IGameLogic
    {
        public void SaveHand();
        Hand GetHand(int id);
        void UpdateHand(int id, List<int> replaceNumbersAt);
    }
}
