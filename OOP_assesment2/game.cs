﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class game
    {
        /// <summary>
        /// creating a protected function to be inherited by the children
        /// classes Three_or_more and Sevens_out
        /// </summary>
        /// <returns>a new die number between 1 and 6</returns>
        public virtual int RollNum()
        {
            //creating new dice object
            var Dice = new Die();

            //returning new dice roll
            return Dice.Roll();
        }


        /// <summary>
        /// creates a new array of size n
        /// </summary>
        /// <param name="n">size of the array</param>
        /// <returns>new array of length n</returns>
        protected int[] NewArray(int n)
        {
            //returning a new array of length n
            return new int[n];
        }
        protected int[] RollDie(int x)
        {
            //creating a new array x length
            int[] new_Array = NewArray(x);

            //looping x amount of times, adding a new dice to the 
            //array every time
            for (int i = 0; i < new_Array.Length; i++)
            {
                //adding the die to the array
                new_Array[i] = RollNum();
            }

            //returning the array containing the die
            return new_Array;
        }

        /// <summary>
        /// getting user input for selections
        /// </summary>
        /// <param name="question">the string of text to be outputted on the terminal</param>
        /// <param name="num">the number of options to chose from</param>
        /// <param name="min">the minimum value</param>
        /// <returns>the user selection</returns>
        public static int NewSelection(string question, int num, int min)
        {
            //creating an empty int to store the selection value
            int selection = 0;

            //looping until it is broken out of
            while (true)
            {
                //adding try and catch block for errenous input
                try
                {
                    //outputting the question to the user
                    Console.WriteLine(question);

                    //taking the user input and turning it into an int
                    selection = int.Parse(Console.ReadLine());

                    //cheking if the user input is valid
                    if (selection >= min && selection <= num)
                    {
                        //breaking out of the loop
                        break;
                    }
                    //if user input is out of range
                    Console.WriteLine("please enter a number between " + min + " - " + num);
                }
                catch
                {
                    //outputting an error message
                    Console.WriteLine("invalid input");
                }
            }
            //returning the final user input
            return selection;

        }
        /// <summary>
        /// displays the current set of dice
        /// </summary>
        /// <param name="dice"> an array of dice </param>
        public virtual void DisplayRoll(int[] dice)
        {
            //outputting all dice
            Console.WriteLine("dice = " + dice[0] + ", " + dice[1]);
        }

        /// <summary>
        /// creating an instance of the random function so it isn't
        /// called multiple times throughout the code
        /// </summary>

        public static Random RandomInstance { get; } = new Random();

        /// <summary>
        /// the Main function where all of the code is run from 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //creating an instance of the statistics class
            var stats = new statistics();            

            //setting the exit boolean to false 
            bool exit = false;

            //loop that will repeat until the user decides to exit
            while (exit == false) 
            {
                int selection = NewSelection("1.Sevens out - 2.three or more - 3.statistics - 4.Test - 5.exit", 5, 1);
                
                
                //if the user selects the number 1 it will run the sevens out Game
                //then it will check if there is a new high score by calling the Update
                //function from the statistics class
                if (selection == 1)
                {
                    //creating a new instance of the sevens out Game
                    var sevens = new Sevens__out();

                    //running the Game and storing the returned final score
                    int score = sevens.Main();

                    //updating the statistics
                    stats.Update(score, 1);
                }
                //if the user selects 2 it will run the three or more Game
                else if(selection == 2)
                {
                    //creating a new instance of three or more
                    var threes = new Three_or_more();

                    //running the Game
                    threes.Main();

                    //updating the Game accordingly
                    stats.Update(0, 2);

                }
                //if the user selects 3 then it will call the Stats function from the statistics class
                else if (selection == 3)
                {
                    //outputting the statistics
                    stats.Stats();
                }
                //if 4 is selected it will test the code
                else if (selection == 4)
                {
                    //creating a new instance of the Test class
                    var test = new Testing();

                    //calling the Test function
                    test.Test();

                }
                //if selection is 5 it will end the code
                else if (selection == 5)
                {
                    //will exit the Game class, in turn exiting the Game
                    Console.WriteLine("exiting....");

                    return;
                }

            }
            
        }
    }
}
