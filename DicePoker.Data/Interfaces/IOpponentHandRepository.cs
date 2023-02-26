using DicePoker.Domain.Models;

namespace DicePoker.Data.Interfaces
{
    public interface IOpponentHandRepository
    {
        OpponentHand SaveOpponentHand(string numbers, int numberOfThrows);
        OpponentHand GetOpponentHand(int id);
        void UpdateOpponentHand(OpponentHand hand);
    }
}
