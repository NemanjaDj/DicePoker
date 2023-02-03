using DicePoker.Data.Interfaces;
using DicePoker.Domain.AppDbContext;
using DicePoker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DicePoker.Data.Repositories
{
    public class HandPowerRepository : IHandPowerRepository
    {
        private readonly AppDbContext context;

        public HandPowerRepository()
        {
            context = new AppDbContext();
        }

        public void SaveHandPower(HandPower handPower)
        {
            context.HandPower.Add(handPower);
            context.SaveChanges();
        }
    }
}
