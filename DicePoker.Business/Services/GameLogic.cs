using DicePoker.Api.Extensions;
using DicePoker.Business.Interfaces;
using DicePoker.Data.Interfaces;
using DicePoker.Domain.Enum;
using DicePoker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker.Business.Services
{
    public class GameLogic : IGameLogic
    {
        #region class properties

        private readonly IHandRepository _handRepository;
        private readonly IOpponentHandRepository _opponentHandRepository;

        #endregion

        #region constructors

        public GameLogic(IHandRepository handRepository, IOpponentHandRepository opponentHandRepository)
        {
            _handRepository = handRepository;
            _opponentHandRepository = opponentHandRepository;
        }

        #endregion

        #region public methods

        public Hand SaveHand()
        {
            List<int> hand = ThrowDices();

            return _handRepository.SaveHand(CastListOfIntsToString(hand), 1);
        }

        public Hand GetHand(int id)
        {
            return _handRepository.GetHand(id);
        }

        public Hand UpdateHand(int id, List<int> replaceNumbersAt)
        {
            Hand hand = GetHand(id);

            if(hand.NumberOfThrows >= 3)
            {
                throw new ArgumentException();
            }

            hand.NumberOfThrows++;
            hand.Numbers = ReplaceNumbersInHand(hand.Numbers, replaceNumbersAt);

            _handRepository.UpdateHand(hand);

            return hand;
        }

        public OpponentHand SaveOpponentHand()
        {
            List<int> hand = ThrowDices();

            return _opponentHandRepository.SaveOpponentHand(CastListOfIntsToString(hand), 1);
        }

        public OpponentHand GetOpponentHand(int id)
        {
            return _opponentHandRepository.GetOpponentHand(id);
        }

        #endregion

        #region private methods

        private string ReplaceNumbersInHand(string handNumbers, List<int> replaceNumbersAt)
        {
            List<int> numbers = handNumbers.ConvertToListOfNumbers();

            foreach (int indexAt in replaceNumbersAt)
            {
                numbers[indexAt] = GetRandomNumber();
            }

            return CastListOfIntsToString(numbers);
        }

        private List<int> ThrowDices()
        {
            List<int> resultList = new List<int>();

            for (int i = 1; i <= 5; i++)
            {
                resultList.Add(GetRandomNumber());
            }

            return resultList;
        }

        private int GetRandomNumber()
        {
            return new Random().Next(1, 7);
        }

        private string CastListOfIntsToString(List<int> numbers)
        {
            string resultString = string.Empty;
            foreach (int i in numbers)
            {
                resultString = resultString + "-" + i;
            }

            return resultString.Substring(1, resultString.Length - 1);
        }

        #endregion
    }
}
