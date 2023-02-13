using DicePoker.Business.Interfaces;
using DicePoker.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public Hand Post()
        {
            return _gameLogic.SaveHand();
        }

        [HttpPut]
        public IActionResult Put(int id, List<int> replaceNumbersAt)
        {
            try
            {
                return Ok(_gameLogic.UpdateHand(id, replaceNumbersAt));
            }
            catch (ArgumentException argException)
            {
                return BadRequest();
            }
        }
    }
}
