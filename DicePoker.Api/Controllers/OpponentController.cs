using DicePoker.Business.Interfaces;
using DicePoker.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DicePoker.Api.Controllers
{
    [Route("api/[controller]")]
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
