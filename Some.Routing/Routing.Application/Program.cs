/* 
 * Programmer: Baran Topal                   *
 * Solution name: Some.Routing               *
 * Folder name: Routing.Application          *
 * Project name: Some.Routing                *
 * File name: Program.cs                     *
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

namespace Some.Routing
{
    /// <summary>
    /// Program to access the main gate
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Enter the alphanumeric characters
            // E.g. 4673212345
            Console.WriteLine("Enter the alphanumeric characters: ");

            // Create Routing object and pass it to its constructor
            Routing r = new Routing();
            string input = Console.ReadLine();

            // Clean the user input and strip out delimiters
            string clean = r.Clean(input);

            // Populate the clean input and form a binary tree which will be balanced
            r.Populate(clean);

            // Read file content
            r.Read("List.txt");

            // Display the result
            r.DisplayAll();
        }
    }
}
