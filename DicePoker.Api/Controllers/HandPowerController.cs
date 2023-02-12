using DicePoker.Business.Interfaces;
using DicePoker.Domain.Models;
using Microsoft.AspNetCore.Mvc;


// TODO
namespace DicePoker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandPowerController : ControllerBase
    {
        private readonly IHandPowerLogic _handPowerLogic;

        public HandPowerController(IHandPowerLogic handPowerLogic)
        {
            _handPowerLogic = handPowerLogic;
        }

        [HttpGet]
        public HandPower Get(int id)
        {
            return _handPowerLogic.GetHandPower(id);
        }

        [HttpPost]
        public HandPower Post(int id)
        {
            return _handPowerLogic.SaveHandPower(id);
        }

    }
}
