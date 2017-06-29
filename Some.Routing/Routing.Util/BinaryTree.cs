/* 
 * Programmer: Baran Topal                   *
 * Solution name: Some.Routing               *
 * Folder name: Routing.Util                 *
 * Project name: Some.Routing                *
 * File name: BinaryTree.cs                  *
 *                                           *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

//http://stackoverflow.com/questions/10366402/binary-search-tree-in-c-sharp-implementation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Some.Routing
{
    /// <summary>
    /// Node class to construct nodes
    /// </summary>
    public class Node
    {
        // Member variables
        public int value;
        public Node Right;
        public Node Left;

        /// <summary>
        /// Non-default *ctor
        /// </summary>
        /// <param name="value"></param> 
        public Node(int value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Binary Search Tree class
    /// </summary>
    public class BST
    {
        public Node Root;

        /// <summary>
        /// Default ctor
        /// </summary> 
        public BST()
        { }

        /// <summary>
        /// Adding the incoming value to tree
        /// </summary>
        /// <param name="new_value"></param>
        public void Add(int new_value)
        {
            if (Search(new_value))
            {
                Console.WriteLine("The specified value (" + new_value + ") is already in the tree");
            }
            else
            {
                AddNode(ref Root, new_value);
            }
        }

        /// <summary>
        /// Adding the node and use the reference of Actual node to update
        /// </summary>
        /// <param name="Actual"></param>
        /// <param name="new_value"></param>
        public void AddNode(ref Node Actual, int new_value)
        {

            if (Actual == null)
            {
                Actual = new Node(new_value);
            }
            else if (new_value < Actual.value)
            {
                AddNode(ref Actual.Left, new_value);
            }
            else if (new_value > Actual.value)
            {
                AddNode(ref Actual.Right, new_value);
            }
        }

        /// <summary>
        /// Searching the incoming int value and place the value as a node
        /// </summary>
        /// <param name="hledane"></param>
        /// <returns></returns>
        public bool Search(int value)
        {
            Node Actual = this.Root;

            while (Actual != null)
            {
                if (value < Actual.value)
                {
                    Actual = Actual.Left;
                }
                else if (value > Actual.value)
                {
                    Actual = Actual.Right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Display the tree values
        /// </summary>
        /// <returns></returns>
        public int Display()
        {
            return (DisplayUndertree(this.Root, 0));
        }

        public int DisplayUndertree(Node EnterNode, int deep)
        {
            if (EnterNode != null)
            {
                for (int i = 1; i <= deep; i++)
                {
                    Console.Write("\t");
                }
                Console.WriteLine(EnterNode.value);
                return EnterNode.value;
            }

            if (EnterNode.Left != null)
            {
                DisplayUndertree(EnterNode.Left, deep + 1);
            }

            if (EnterNode.Right != null)
            {
                DisplayUndertree(EnterNode.Right, deep + 1);
            }
            return -1;
        }
    }
}