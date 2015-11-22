using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrypticCities.Core
{
    public class Numbers
    {
        /// <summary>
        /// Returns all numbers, between min and max inclusive, once in a random sequence.
        /// </summary>
        public static IEnumerable<int> UniqueRandom(int minInclusive, int maxInclusive)
        {
            List<int> candidates = new List<int>();
            for (int i = minInclusive; i <= maxInclusive; i++)
            {
                candidates.Add(i);
            }
            Random rnd = new Random();
            while (candidates.Count > 0)
            {
                int index = rnd.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }

        public static string GenerateHintSequence(int sequenceLength)
        {
            var hintSequenceNumbers = UniqueRandom(1, sequenceLength);
            string hintSequence = "";

            foreach (var number in hintSequenceNumbers)
            {
                hintSequence += number.ToString() + ",";
            }

            return hintSequence.TrimEnd(',');
        }

        public static IEnumerable<int> ParseHintSequence(string hintSequence)
        {
            var hintSequenceArray = hintSequence.Split(',');

            List<int> hintSequenceList = new List<int>();

            foreach (var value in hintSequenceArray)
            {
                hintSequenceList.Add(int.Parse(value));
            }

            return hintSequenceList;

        }

    }

}