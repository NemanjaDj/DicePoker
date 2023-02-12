using DicePoker.Api.Extensions;
using DicePoker.Business.Interfaces;
using DicePoker.Data.Interfaces;
using DicePoker.Domain.Enum;
using DicePoker.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker.Business.Services
{
    public class HandPowerLogic : IHandPowerLogic
    {
        private readonly IHandPowerRepository _handPowerRepository;
        private readonly IHandRepository _handRepository;

        public HandPowerLogic(IHandPowerRepository handPowerRepository, IHandRepository handRepository)
        {
            _handPowerRepository = handPowerRepository;
            _handRepository = handRepository;
        }

        #region implementation

        public HandPower GetHandPower(int handId)
        {
            return _handPowerRepository.GetHandPower(handId);
        }

        public HandPower SaveHandPower(int handId)
        {
            string hand = _handRepository.GetHand(handId).Numbers;
            List<int> numbers = GetGroupedListOfNumbers(hand.ConvertToListOfNumbers());
            HandPower handPower = GetPowerOfHand(numbers, handId);

            _handPowerRepository.SaveHandPower(handPower);

            return handPower;
        }

        #endregion

        #region private methods

        private HandPower GetPowerOfHand(List<int> numbers, int handId)
        {
            HandPower newHandPower = new HandPower();

            newHandPower.HandId = handId;
            newHandPower.handPowerType = GetHandPowerType(numbers);
            newHandPower.LeadNumber = GetLeadNumber(numbers, newHandPower.handPowerType);

            if (newHandPower.handPowerType == HandPowerType.FullHouse)
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
            if (numbers[0] == 1 && numbers[5] == 1)
            {
                return HandPowerType.Bust;
            }

            return HandPowerType.Straight;
        }

        private HandPowerType CheckIfItIsTwoPairs(List<int> numbers)
        {
            if (numbers.Where(n => n == 2).Count() > 1)
            {
                return HandPowerType.TwoPairs;
            }

            return HandPowerType.Pair;
        }

        private int GetLeadNumber(List<int> numbers, HandPowerType handPowerType)
        {
            if (handPowerType == HandPowerType.Straight && numbers[5] == 1)
            {
                return 6;
            }
            else if (handPowerType == HandPowerType.Straight)
            {
                return 5;
            }

            if (handPowerType == HandPowerType.FiveOfAKind)
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
            for (int i = 5; i > 0; i--)
            {
                if (numbers[i] == 2)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        private List<int> GetGroupedListOfNumbers(List<int> numbers)
        {
            List<int> groupedListOfNumbers = new List<int>(6) { 0, 0, 0, 0, 0, 0 };

            foreach (int i in numbers)
            {
                groupedListOfNumbers[i - 1]++;
            }

            return groupedListOfNumbers;
        }

        #endregion
    }
}
