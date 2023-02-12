using DicePoker.Data.Interfaces;
using DicePoker.Domain.AppDbContext;
using DicePoker.Domain.Models;
using System.Linq;

namespace DicePoker.Data.Repositories
{
    public class HandPowerRepository : IHandPowerRepository
    {
        private readonly AppDbContext context;

        public HandPowerRepository()
        {
            context = new AppDbContext();
        }

        public HandPower GetHandPower(int handId)
        {
            return context.HandPower.FirstOrDefault(hp => hp.HandId == handId);
        }

        public void SaveHandPower(HandPower handPower)
        {
            context.HandPower.Add(handPower);
            context.SaveChanges();
        }
    }
}
