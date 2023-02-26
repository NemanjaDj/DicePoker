using DicePoker.Data.Interfaces;
using DicePoker.Domain.AppDbContext;
using DicePoker.Domain.Models;

namespace DicePoker.Data.Repositories
{
    public class HandRepository : IHandRepository
    {

        private readonly AppDbContext context;

        public HandRepository()
        {
            context = new AppDbContext();
        }

        public Hand GetHand(int id)
        {
            return context.Find<Hand>(id);
        }

        public Hand SaveHand(string numbers, int numberOfThrows)
        {
            Hand newHand = new Hand() { Numbers = numbers, NumberOfThrows = numberOfThrows};
            context.Hand.Add(newHand);
            context.SaveChanges();

            return newHand;
        }

        public void UpdateHand(Hand hand)
        {
            context.Update(hand);
            context.SaveChanges();
        }
    }
}
