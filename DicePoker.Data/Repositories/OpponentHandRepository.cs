using DicePoker.Data.Interfaces;
using DicePoker.Domain.AppDbContext;
using DicePoker.Domain.Models;
using System;

namespace DicePoker.Data.Repositories
{
    public class OpponentHandRepository : IOpponentHandRepository
    {
        private readonly AppDbContext context;

        public OpponentHandRepository()
        {
            context = new AppDbContext();
        }

        public OpponentHand GetOpponentHand(int id)
        {
            throw new NotImplementedException();
        }

        public OpponentHand SaveOpponentHand(string numbers, int numberOfThrows)
        {
            OpponentHand newHand = new OpponentHand() { HandNumbers = numbers, NumberOfThrows = numberOfThrows };
            context.OpponentHand.Add(newHand);
            context.SaveChanges();

            return newHand;
        }

        public void UpdateOpponentHand(OpponentHand hand)
        {
            throw new NotImplementedException();
        }
    }
}
