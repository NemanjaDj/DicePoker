using DicePoker.Domain.Models;
using System.Collections.Generic;

namespace DicePoker.Business.Interfaces
{
    public interface IGameLogic
    {
        Hand SaveHand();
        Hand GetHand(int id);
        Hand UpdateHand(int id, List<int> replaceNumbersAt);
        OpponentHand SaveOpponentHand();
        OpponentHand GetOpponentHand(int id);
    }
}
