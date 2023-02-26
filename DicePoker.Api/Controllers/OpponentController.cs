using DicePoker.Business.Interfaces;
using DicePoker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DicePoker.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OpponentController : ControllerBase
    {
        private readonly IGameLogic _gameLogic;

        public OpponentController(IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        [HttpGet]
        public OpponentHand Get(int id)
        {
            return _gameLogic.GetOpponentHand(id);
        }

        [HttpPost]
        public OpponentHand Post()
        {
            return _gameLogic.SaveOpponentHand();
        }

        //[HttpPut]
        //public IActionResult Put(int id, List<int> replaceNumbersAt)
        //{
        //    try
        //    {
        //        return Ok(_gameLogic.UpdateHand(id, replaceNumbersAt));
        //    }
        //    catch (ArgumentException argException)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
