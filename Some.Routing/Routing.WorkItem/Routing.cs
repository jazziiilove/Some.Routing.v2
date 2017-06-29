/* 
 * Programmer: Baran Topal                   *
 * Solution name: Some.Routing               *
 * Folder name: Routing.WorkItem             *
 * Project name: Some.Routing                *
 * File name: Routing.cs                     *
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
using System.IO;

namespace Some.Routing
{
    /// <summary>
    /// Routing class to cover entities and functional requirements
    /// </summary>
    public class Routing
    {
        /// <summary>
        /// BST instance to add the elements to the tree
        /// </summary>
        private BST binarySearchTree = new BST();

        /// <summary>
        /// SortedDictionary to have the matching nodes
        /// </summary>
        private SortedDictionary<string, string> dict;

        /// <summary>
        /// Accessor for binarySearchTree instance
        /// </summary>
        public BST BinarySearchTree
        {
            get { return binarySearchTree; }
        }

        /// <summary>
        /// Accessor for dict instance
        /// </summary>
        public SortedDictionary<string, string> Dict
        {
            get { return dict; }
            set { dict = value; }
        }

        /// <summary>
        /// Accessor storing prefix
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Accessor storing price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Accessor  storing operator letter
        /// </summary>
        public char Letter { get; set; }

        /// <summary>
        /// Search function to find out whether the incoming prefix matches
        /// </summary>
        /// <returns></returns>
        public bool Search()
        {
            if (binarySearchTree.Search(Int32.Parse(Prefix)))
            {
                // Add prefix and matching price to dictionary
                dict.Add(Prefix, Price);

                // Search success
                return true;
            }
            // Search failure
            return false;
        }

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Read(string path)
        {
            string line;
            dict = new SortedDictionary<string, string>();

            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        // Splitting line into atoms where the first atom represents prefix, and third atom represents a operator numerical code                                                        
                        if (!line.StartsWith("O"))
                        {
                            string[] atoms = line.Split(new char[] { ' ', '\t' });
                            Prefix = atoms[0];
                            Price = atoms[2];
                            Search();
                        }
                        else
                        {
                            // Display the result, skip for the first use
                            DisplayAll();

                            // Clear the content
                            dict.Clear();
                            Letter = line[line.Length - 2];
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
                sr.Close();
                return true;
            }
        }

        /// <summary>
        /// Display all the result
        /// </summary>
        /// <returns></returns>
        public string DisplayAll()
        {
            try
            {
                // Empty dictionary, no match
                if (dict.Count != 0)
                {
                    var lastKey = dict.Keys.Last();
                    var lastValue = dict.Values.Last();
                    string s = Letter + " has the longest matching prefix: " + lastKey + " and its price: " + lastValue;
                    Console.WriteLine(s);
                    return s;
                }
                else
                {
                    // Letter must be assigned
                    if (Letter != '\0')
                    {
                        string s = Letter + " has no matching prefix.";
                        Console.WriteLine(s);
                        return s;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Invalid";
            }
            return "";
        }

        /// <summary>
        /// Clean the user input, check whether the char is a digit or not
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Clean(string input)
        {
            // A LINQ query to check for input and clean
            return (new String(input.Where(Char.IsDigit).ToArray()));
        }

        /// <summary>
        /// Add the cleaned input, e.g. 4673212 as 4, 46, etc.
        /// </summary>
        /// <param name="input"></param>
        public void Populate(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string str = input.Substring(0, i + 1);
                binarySearchTree.Add(Int32.Parse(str));
            }
        }
    }
}
