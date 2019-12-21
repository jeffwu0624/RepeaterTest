using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepeaterTest
{
    [TestClass]
    public class CharacterRepeaterTest
    {
        [TestMethod]
        public void test_One_Lower_Character()
        {
            var characterRepeater = new CharacterRepeater();

            var actual = characterRepeater.Convert("a");

            Assert.AreEqual("A", actual);
        }

        [TestMethod]
        public void test_Two_Lower_Character()
        {
            var characterRepeater = new CharacterRepeater();

            var actual = characterRepeater.Convert("ab");

            Assert.AreEqual("A-Bb", actual);
        }
        [TestMethod]
        public void test_Three_Max_Upper_Character()
        {
            var characterRepeater = new CharacterRepeater();

            var actual = characterRepeater.Convert("AbC");

            Assert.AreEqual("A-Bb-Ccc", actual);
        }

        [TestMethod]
        public void test_With_No_Character()
        {
            var characterRepeater = new CharacterRepeater();

            var actual = characterRepeater.Convert("a1b");

            Assert.AreEqual("A-11-Bbb", actual);
        }
    }

    public class CharacterRepeater
    {
        public string Convert(string input)
        {
            var result = new List<string>();

            var count = 1;

            foreach (var character in input.ToCharArray())
            {
                var firstChar = character.ToString().ToUpper();

                var secondChar = count > 1
                    ? string.Join("", Enumerable.Repeat(character, count - 1)).ToLower()
                    : "";

                result.Add($"{firstChar}{secondChar}");

                count++;
            }

            return string.Join("-", result);
        }
    }
}
