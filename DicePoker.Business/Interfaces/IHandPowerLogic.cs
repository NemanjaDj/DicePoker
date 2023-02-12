using DicePoker.Domain.Models;
using System.Collections.Generic;

namespace DicePoker.Business.Interfaces
{
    public interface IHandPowerLogic
    {
        HandPower SaveHandPower(int handId);
        HandPower GetHandPower(int handId);
    }
}
