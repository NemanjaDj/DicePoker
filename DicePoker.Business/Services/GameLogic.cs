using DicePoker.Business.Interfaces;
using DicePoker.Data.Interfaces;
using DicePoker.Domain.Enum;
using DicePoker.Domain.Models;
using System;
using System.Collections.Generic;

namespace DicePoker.Business.Services
{
    public class GameLogic : IGameLogic
    {
        #region class properties

        private readonly IHandRepository _handRepository;
        private readonly IHandPowerRepository _handPowerRepository;

        #endregion

        #region constructors

        public GameLogic(IHandRepository handRepository, IHandPowerRepository handPowerRepository)
        {
            _handRepository = handRepository;
            _handPowerRepository = handPowerRepository;
        }

        #endregion

        #region public methods

        public void SaveHand()
        {
            List<int> hand = ThrowDices();
            HandPower handPower = GetPowerOfHand(GetGroupedListOfNumbers(hand));
            
            _handRepository.SaveHand(CastListOfIntsToString(hand), 1);
            _handPowerRepository.SaveHandPower(handPower);
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

        private HandPower GetPowerOfHand(List<int> numbers)
        {
            HandPower newHandPower = new HandPower();

            newHandPower.HandId = 1;
            newHandPower.LeadNumber = 1;
            newHandPower.FollowingNumber = 3;

            //TO-DO
            if (numbers.Contains(5))
            {
                newHandPower.handPowerType = HandPowerType.FiveOfAKind;
            }
            else if (numbers.Contains(4))
            {
                newHandPower.handPowerType = HandPowerType.FourOfAKind;
            }
            else if (numbers.Contains(3) && numbers.Contains(2))
            {
                newHandPower.handPowerType = HandPowerType.FullHouse;
            }
            else if (numbers.Contains(3) && numbers.Contains(2))
            {
                newHandPower.handPowerType = HandPowerType.FullHouse;
            }
            else if (numbers.Contains(3))
            {
                newHandPower.handPowerType = HandPowerType.ThreeOfAKind;
            }
            else if (numbers.Contains(2))
            {
                newHandPower.handPowerType = HandPowerType.TwoPairs;
            }
            else
            {
                newHandPower.handPowerType = HandPowerType.Straight;
            }

            return newHandPower;
        }

        private List<int> GetGroupedListOfNumbers(List<int> numbers)
        {
            List<int> groupedListOfNumbers = new List<int>(6) { 0, 0, 0, 0, 0, 0};

            foreach (int i in numbers)
            {
                groupedListOfNumbers[i - 1]++;
            }

            return groupedListOfNumbers;
        }


        #endregion
    }
}
