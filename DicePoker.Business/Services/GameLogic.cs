using DicePoker.Business.Interfaces;
using DicePoker.Data.Interfaces;
using DicePoker.Domain.Models;
using System;
using System.Collections.Generic;

namespace DicePoker.Business.Services
{
    public class GameLogic : IGameLogic
    {
        #region class properties

        private readonly IHandRepository _handRepository;

        #endregion

        #region constructors

        public GameLogic(IHandRepository handRepository)
        {
            _handRepository = handRepository;
        }

        #endregion

        #region public methods

        public void SaveHand()
        {
            List<int> hand = ThrowDices();
            _handRepository.SaveHand(CastListOfIntsToString(hand), 1);
        }

        public Hand GetHand(int id)
        {
            return _handRepository.GetHand(id);
        }

        public void UpdateHand(int id, List<int> replaceNumbersAt)
        {
            Hand hand = GetHand(id);

            hand.Numbers = ReplaceNumbersInHand(hand.Numbers, replaceNumbersAt);

            _handRepository.UpdateHand(hand);
        }

        #endregion

        #region private methods

        private string ReplaceNumbersInHand(string handNumbers, List<int> replaceNumbersAt)
        {
            List<int> numbers = StringOfNumebrsToList(handNumbers);

            foreach (int indexAt in replaceNumbersAt)
            {
                numbers[indexAt - 1] = GetRandomNumber();
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
            Random random = new Random();
            return random.Next(1, 6);
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

        private List<int> StringOfNumebrsToList(string numbers)
        {
            List<int> resultList = new List<int>();

            string formatedNumbers = numbers.Replace("-", "");

            foreach (char c in formatedNumbers)
            {
                resultList.Add((int)char.GetNumericValue(c));
            }

            return resultList;
        }

        private int GetPowerOfHand()
        {
            //TO-DO

            return 0;
        }

        #endregion
    }
}
