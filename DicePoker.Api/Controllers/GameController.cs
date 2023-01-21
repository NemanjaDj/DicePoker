using DicePoker.Business.Interfaces;
using DicePoker.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DicePoker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly IGameLogic _gameLogic;

        public GameController(IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        [HttpGet]
        public Hand Get(int id)
        {
            return _gameLogic.GetHand(id);
        }

        [HttpPost]
        public void Post()
        {
            _gameLogic.SaveHand();
        }

        [HttpPut]
        public void Put(int id, List<int> replaceNumbersAt)
        {
            _gameLogic.UpdateHand(id, replaceNumbersAt);
        }
    }
}
