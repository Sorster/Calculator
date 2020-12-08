using System;
using System.Runtime.InteropServices;

namespace ConsoleApp2
{
    class Calculator
    {
        //The function return the operation choice
        static int Menu()
        {
            int choice;

            Console.Write("Menu: \n1.(+)\n2.(-)\n3.(*)\n4.(/)\n5.Percentage of the first number of the second one\n6.Square root\n7.Show the last results (max 5)\n8.Close the program\nCommand:>");
            do
            {
                //check the right number input
                if (int.TryParse(Console.ReadLine(), out choice)) break;

                else
                {
                    Console.WriteLine("Error! Please retry your input!");
                }
            } while (true);

            Console.Clear();

            return choice;
        }

        //The function input a number and check this one
        static double NumberInput()
        {
            double number;
            do
            {
                var num = Console.ReadLine();

                //check the right number input
                if (double.TryParse(num, out number))
                {
                    break;
                }
                else
                {
                    Console.Write("Error! Please rewrite this number: ");
                }

            } while (true);

            return number;
        }

        //The function summarize two numbers
        static double Sum(double fNum, double sNum)
        {
            return fNum + sNum;
        }

        //The function substract two numbers
        static double Sab(double fNum, double sNum)
        {
            return fNum - sNum;
        }

        //The function multiply two numbers
        static double Mult(double fNum, double sNum)
        {
            return fNum * sNum;
        }

        //The function divide two numbers and check a division by 0
        static double Div(double fNum, double sNum)
        {
            bool check = true;

            do
            {
                if (sNum == 0)
                {
                    Console.WriteLine("Error! The second number is 0! Please rewrite the second number!");
                    sNum = NumberInput();
                }
                else check = false;

            } while (check);

            return fNum / sNum;
        }

        //The function count the second number percentage of the first one
        static double Percentage(double fNum, double sNum)
        {
            //if the second number is 0 the function will return 0 (division by 0)
            if (sNum == 0)
            {
                Console.WriteLine("Error! The second number is 0");
                return 0;
            }
            else return Math.Abs(fNum) / Math.Abs(sNum) * 100;
        }

        //The function count a square root of a number
        static double SquareRoot(double Num)
        {
            //if the number is negative the function will return 0
            if (Num < 0)
            {
                return 0;
            }
            else
            {
                return Math.Sqrt(Num);
            }
        }

        //The function ask a user whether or not he want to continue the program 
        static bool YesOrNo()
        {
            string choice;

            do
            {
                Console.WriteLine("Do you want to repeat the operation? (yes/no)");
                choice = Console.ReadLine();

                //transform case
                choice = choice.ToLower();

                //Check the right input 
                if (!(choice.Equals("yes")) && !(choice.Equals("no"))) Console.WriteLine("Please rewrite your decision!");
                else break;

            } while (true);

            Console.Clear();

            if (choice.Equals("yes")) return true;

            else return false;
        }

        // If you want to be asked whether to save a result or not
        /*static bool SaveInArray()
        {

            string choice;
            do
            {
                Console.WriteLine("\nDo you want to save the result?");    
                choice = Console.ReadLine();
                choice = choice.ToLower();

                if (!(choice.Equals("yes")) && !(choice.Equals("no"))) Console.WriteLine("Please rewrite your decision!");
        
                else break;

            } while (true);

            if (choice.Equals("yes")) return true;
            
            else return false;
        }*/

        static void Main(string[] args)
        {
            //a variable for a result
            double result = 0;

            //an array of results
            double[] results = new double[5];

            //a variable for saving the result in the array
            int counter = 0;

            //a variable for saving a choice
            int choice = -1;

            double firstNumber = 0, secondNumber = 0;

            do
            {
                //choice == -1 mean that this is begining of the program
                if (choice == -1)
                {
                    choice = Menu();
                }

                //the exit condition
                if (choice == 8) break;

                if (choice != 7 && choice != 6)
                {
                    Console.Write("Input the first number: ");
                    firstNumber = NumberInput();

                    Console.Write("Input the second number: ");
                    secondNumber = NumberInput();
                }

                switch (choice)
                {
                    //The sum of the elements
                    case 1:
                        {
                            result = Sum(firstNumber, secondNumber);
                            break;
                        }
                    //The substraction of the elements
                    case 2:
                        {
                            result = Sab(firstNumber, secondNumber);
                            break;
                        }
                    //The composition of the elements
                    case 3:
                        {
                            result = Mult(firstNumber, secondNumber);
                            break;
                        }
                    //The division of the elements 
                    case 4:
                        {
                            result = Div(firstNumber, secondNumber);
                            break;
                        }
                    //The second number percentage of the first one 
                    case 5:
                        {
                            result = Percentage(firstNumber, secondNumber);
                            break;
                        }
                    //Square root of the number
                    case 6:
                        {
                            var number = NumberInput();

                            result = SquareRoot(number);

                            if (SquareRoot(number) == 0) Console.WriteLine("\nThis number is lower than 0!");

                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error! Please input a number from 1 to 8!");
                            break;
                        }
                }

                //the result output
                if (choice == 7)
                {
                    for (int j = 0; j < counter; j++)
                    {
                        Console.Write($"The result of operation {j + 1}: {results[j]}\n");
                    }

                    Console.WriteLine("Input any key to continue...");

                    Console.ReadKey();

                    Console.Clear();
                }
                else if (choice == 5)
                {
                    Console.WriteLine($"Result: {result:P}");
                }
                else
                {
                    Console.WriteLine($"Result: {result}");
                }

                //if (SaveInArray())
                {
                    if (counter == 5)
                    {
                        for (int j = 1; j < 5; j++)
                        {
                            results[j - 1] = results[j];
                        }

                        counter = 4;
                    }

                    results[counter] = result;
                    counter++;
                }

                //continuation condition of the operation
                if (choice == 7)
                {
                    choice = Menu();
                }
                else if (!YesOrNo())
                {
                    choice = Menu();
                }

            } while (true);
        }
    }
}