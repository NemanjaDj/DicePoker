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
            newHandPower.handPowerType = GetHandPowerType(numbers);
            newHandPower.LeadNumber = GetLeadNumber(numbers, newHandPower.handPowerType);
            
            if(newHandPower.handPowerType == HandPowerType.FullHouse)
            {
                newHandPower.FollowingNumber = GetFollowingNumber(numbers);
            }

            return newHandPower;
        }

        private HandPowerType GetHandPowerType(List<int> numbers)
        {
            if (numbers.Contains(5))
            {
                return HandPowerType.FiveOfAKind;
            }
            else if (numbers.Contains(4))
            {
                return HandPowerType.FourOfAKind;
            }
            else if (numbers.Contains(3) && numbers.Contains(2))
            {
                return HandPowerType.FullHouse;
            }
            else if (numbers.Contains(3))
            {
                return HandPowerType.ThreeOfAKind;
            }
            else if (numbers.Contains(2))
            {
                return CheckIfItIsTwoPairs(numbers);
            }

            return CheckIfItIsStraight(numbers);
        }

        private HandPowerType CheckIfItIsStraight(List<int> numbers)
        {
            if(numbers[0] == 1 && numbers[5] == 1)
            {
                return HandPowerType.Bust;
            }

            return HandPowerType.Straight;
        }

        private HandPowerType CheckIfItIsTwoPairs(List<int> numbers)
        {
            if(numbers.Where(n => n == 2).Count() > 1)
            {
                return HandPowerType.TwoPairs;
            }

            return HandPowerType.Pair;
        }

        private int GetLeadNumber(List<int> numbers, HandPowerType handPowerType)
        {
            if(handPowerType == HandPowerType.Straight && numbers[5] == 1)
            {
                return 6;
            } else if(handPowerType == HandPowerType.Straight)
            {
                return 5;
            }

            if(handPowerType == HandPowerType.FiveOfAKind)
            {
                return numbers.IndexOf(5) + 1;
            }

            if (handPowerType == HandPowerType.FourOfAKind)
            {
                return numbers.IndexOf(4) + 1;
            }

            if (handPowerType == HandPowerType.FullHouse || handPowerType == HandPowerType.ThreeOfAKind)
            {
                return numbers.IndexOf(3) + 1;
            }

            if (handPowerType == HandPowerType.TwoPairs)
            {
                return GetStrongerPairOfTwoPairs(numbers);
            }

            if (handPowerType == HandPowerType.Pair)
            {
                return numbers.IndexOf(2) + 1;
            }

            return 0;
        }

        private int GetFollowingNumber(List<int> numbers)
        {
            return numbers.IndexOf(2) + 1;
        }

        private int GetStrongerPairOfTwoPairs(List<int> numbers)
        {
            for(int i = 5; i > 0; i--)
            {
                if(numbers[i] == 2)
                {
                    return i + 1;
                }
            }

            return 0;
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
