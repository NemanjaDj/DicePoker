using DicePoker.Domain.Models;

namespace DicePoker.Data.Interfaces
{
    public interface IHandRepository
    {
        Hand SaveHand(string numbers, int numberOfThrows);
        Hand GetHand(int id);
        void UpdateHand(Hand hand);
    }
}
