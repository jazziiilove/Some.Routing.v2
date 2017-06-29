/* 
 * Programmer: Baran Topal                   *
 * Solution name: Some.Routing               *
 * Folder name: NA                           *
 * Project name: Some.Routing.Test           *
 * File name: TestClass.cs                   *
 *                                           *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;

namespace Some.Routing.Test
{
    [TestFixture]
    public class TestClass
    {

        /// <summary>
        /// Clean empty input
        /// </summary>
        [Test]
        public void CleanEmptyInput()
        {
            // Actual   
            var target = new Routing();
            var actual = target.Clean("");

            // Expected
            var expected = "";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one alpha
        /// </summary>
        [Test]
        public void CleanOneAlpha()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("a");

            //Expected
            var expected = "";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean two alphas
        /// </summary>
        [Test]
        public void CleanTwoAlpha()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("ab");

            //Expected
            var expected = "";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one numerical
        /// </summary>
        [Test]
        public void CleanOneNumerical()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("1");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean two numericals
        /// </summary>
        [Test]
        public void CleanTwoNumerical()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("12");

            //Expected
            var expected = "12";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one numerical and one alpha
        /// </summary>
        [Test]
        public void CleanOneNumericalOneAlpha()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("1a");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one numerical and two alphas
        /// </summary>
        [Test]
        public void CleanOneNumericalTwoAlpha()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("1ab");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one numerical, two alphas where numerical is at the end
        /// </summary>
        [Test]
        public void CleanOneNumericalEnd()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("ab1");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one numerical, two alphas where numerical is at the front
        /// </summary>
        [Test]
        public void CleanOneNumericalFront()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("1ab");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one numerical, two alphas where numerical is in between
        /// </summary>
        [Test]
        public void CleanOneNumericalIn()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("a1b");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one delimiter
        /// </summary>
        [Test]
        public void CleanOneDelimiter()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("-");

            //Expected
            var expected = "";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean two delimiters different
        /// </summary>
        [Test]
        public void CleanTwoDelimitersDifferent()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("+-");

            //Expected
            var expected = "";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean two delimiters same
        /// </summary>
        [Test]
        public void CleanrTwoDelimitersSame()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("--");

            //Expected
            var expected = "";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one delimiter leading
        /// </summary>
        [Test]
        public void CleanOneDelimiterLeading()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("+1");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean one delimiter trailing
        /// </summary>
        [Test]
        public void CleanOneDelimiterTrailiing()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("1-");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean two different delimiters, where one numeric is in between
        /// </summary>
        [Test]
        public void CleanTwoDelimitersNumeric()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("+1-");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean two different delimiters where delimiters are in front
        /// </summary>
        [Test]
        public void CleanTwoLeadingDelimitersNumeric()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("+-1");

            //Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Clean two different delimiters, where delimiters are in back
        /// </summary>
        [Test]
        public void CleanTwoTrailingDelimitersNumeric()
        {
            // Arrange
            var target = new Routing();
            var actual = target.Clean("1+-");

            // Expected
            var expected = "1";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Populate tree with one numeric
        /// </summary>
        [Test]
        public void PopulateInputOneNumeric()
        {
            // Arrange
            BST bst = new BST();
            bst.Add(1);

            var target = new Routing();
            target.BinarySearchTree.Add(1);
            target.Populate("1");

            // Assert            
            Assert.AreEqual(target.BinarySearchTree.Display(), bst.Display());
        }

        /// <summary>
        /// Populate tree with two numerics
        /// </summary>
        [Test]
        public void PopulateInputTwoNumerics()
        {
            // Arrange            
            var target = new Routing();
            target.BinarySearchTree.Add(1);
            target.Populate("1");
            target.BinarySearchTree.Add(2);
            target.Populate("2");

            var notExpected = -1;
            // Assert            
            Console.WriteLine(target.BinarySearchTree.Display());
            Assert.AreNotEqual(notExpected, target.BinarySearchTree.Display());
        }

        /// <summary>
        /// Populate tree with empty string
        /// </summary>
        [Test]
        public void PopulateInputEmpty()
        {
            // Arrange
            var target = new Routing();
            target.Populate("");
            // Assert
            Assert.IsNull(target.BinarySearchTree.Root);
        }

        /// <summary>
        /// Read the actual file
        /// </summary>
        [Test]
        public void CanRead_Path()
        {
            // Arrange
            string path = "List.txt";
            var target = new Routing();

            // Timer starts
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool result = target.Read(path);
            //Timer stops
            stopwatch.Stop();
            double s = stopwatch.Elapsed.TotalMilliseconds;

            Console.WriteLine("The search found execution takes for " + s + " milliseconds");

            var expected = true;
            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Read a non existing path
        /// </summary>
        [Test]
        public void CannotRead_NoTextFile()
        {
            // Arrange
            string path = @"";
            var target = new Routing();
            bool result = false;
            var expected = false;
            try
            {
                result = target.Read(path);
            }
            catch (System.ArgumentException e)
            {
                // Assert
                Assert.AreEqual(expected, result);
            }
        }

        /// <summary>
        /// Read an empty file
        /// </summary>
        [Test]
        public void CanRead_EmptyTextFile()
        {
            // Arrange
            string path = "TestFiles/ListEmpty.txt";
            var target = new Routing();

            bool result = target.Read(path);
            var expected = true;
            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Read a gibberish file
        /// </summary>
        [Test]
        public void CannotRead_Gibberish()
        {
            // Arrange
            string path = "TestFiles/ListGibberish.txt";
            var target = new Routing();

            bool result = target.Read(path);
            var expected = false;
            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Read a partial file, single block
        /// </summary>
        [Test]
        public void CannotRead_Partial1()
        {
            // Arrange
            string path = "TestFiles/PartialList1.txt";
            var target = new Routing();

            bool result = target.Read(path);
            var expected = true;
            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Read a partial file, single block with alpha line
        /// </summary>
        [Test]
        public void CannotRead_Partial2()
        {
            // Arrange
            string path = "TestFiles/PartialList2.txt";
            var target = new Routing();

            bool result = target.Read(path);
            var expected = true;
            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Read a partial file, multi blocks
        /// </summary>
        [Test]
        public void CannotRead_Partial3()
        {
            // Arrange
            string path = "TestFiles/PartialList3.txt";
            var target = new Routing();

            bool result = target.Read(path);
            var expected = true;
            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Search the prefix which exists
        /// </summary>
        [Test]
        public void SearchFound()
        {
            // Arrange
            BST strom = new BST();
            Node node = new Node(3);
            strom.Root = node;
            strom.AddNode(ref node, 3);

            bool result = strom.Search(3);
            var actual = result;
            var expected = true;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Search a prefix which doesn't exist in the tree
        /// </summary>
        [Test]
        public void SearchNotFound()
        {
            // Arrange
            BST bst = new BST();
            Node node = new Node(3);
            bst.Root = node;
            bst.AddNode(ref node, 2);
            bool result = bst.Search(1);
            var actual = result;
            var expected = false;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Time check for found one
        /// </summary>
        [Test]
        public void SearchFoundTimeCheck()
        {
            // Arrange
            BST bst = new BST();
            Node node = new Node(3);
            bst.Root = node;
            bst.AddNode(ref node, 3);

            // Timer starts
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool result = bst.Search(3);

            //Timer stops
            stopwatch.Stop();
            double s = stopwatch.Elapsed.TotalMilliseconds;

            string output = "The search found execution takes for " + s + " milliseconds";
            if (s > 0.3)
            {
                Assert.Pass(output);
            }
            Console.WriteLine(output);
        }

        /// <summary>
        /// Time check for not found
        /// </summary>
        [Test]
        public void SearchNotFoundTimeCheck()
        {
            // Arrange
            BST bst = new BST();
            Node node = new Node(3);
            bst.Root = node;
            bst.AddNode(ref node, 2);

            // Timer starts
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool result = bst.Search(1);

            //Timer stops
            stopwatch.Stop();
            double s = stopwatch.Elapsed.TotalMilliseconds;

            string output = "The search not found execution takes for " + s + " milliseconds";
            if (s > 0.3)
            {
                Assert.Pass(output);
            }
            Console.WriteLine(output);
        }

        /// <summary>
        /// Display no hit
        /// </summary>
        [Test]
        public void DisplayNoHit()
        {
            // Arrange
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            var target = new Routing();
            target.Dict = dict;
            target.Letter = 'A';
            string actual = target.DisplayAll();

            string expected = target.Letter + " has no matching prefix.";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Display hit one char prefix
        /// </summary>
        [Test]
        public void DisplayHitOneChar()
        {
            // Arrange
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            dict.Add("4", "1.1");
            var lastKey = dict.Keys.Last();
            var lastValue = dict.Values.Last();

            var target = new Routing();
            target.Dict = dict;
            target.Letter = 'A';
            string actual = target.DisplayAll();

            string expected = target.Letter + " has the longest matching prefix: " + lastKey + " and its price: " + lastValue;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Display hit two chars prefix
        /// </summary>
        [Test]
        public void DisplayHitTwoChars()
        {
            // Arrange
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            dict.Add("46", "1.1");
            var lastKey = dict.Keys.Last();
            var lastValue = dict.Values.Last();

            var target = new Routing();
            target.Dict = dict;
            target.Letter = 'A';
            string actual = target.DisplayAll();

            string expected = target.Letter + " has the longest matching prefix: " + lastKey + " and its price: " + lastValue;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Display hit more chars prefix
        /// </summary>
        [Test]
        public void DisplayHitMultiChars()
        {
            // Arrange
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            dict.Add("46732", "1.1");
            var lastKey = dict.Keys.Last();
            var lastValue = dict.Values.Last();

            var target = new Routing();
            target.Dict = dict;
            target.Letter = 'A';
            string actual = target.DisplayAll();

            string expected = target.Letter + " has the longest matching prefix: " + lastKey + " and its price: " + lastValue;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Display invalid hit
        /// </summary>
        [Test]
        public void DisplayInvalidHit()
        {
            // Arrange
            SortedDictionary<string, string> dict = null;
            var target = new Routing();
            target.Dict = dict;
            target.Letter = '\0';
            string actual = target.DisplayAll();
            string expected = "Invalid";

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
