using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace QuizApplication
{
    class Program
    {
        public enum Difficultylevel
        {
            Easy,
            Normal,
            Hard
        }
        public enum MathOperation
        {
            Addition =1,
            Subtraction = 2,
            Multiplication =3
            //Modulus=4,
            //Division = 5,
            //SaqureRoote=6
        }
        public static (int OperationMin,int OperationMax) GetPossibleOperationsByDifficulty(Difficultylevel difficultylevel)
        {
            switch (difficultylevel)
            {
                case Difficultylevel.Easy:
                    return (1, 3);
                case Difficultylevel .Normal:
                    return (1, 4);
                case Difficultylevel .Hard:
                    return (1, 4);
                    
                default:
                    throw new Exception();

            }
        }
        public static (string message, double correctAnswer) GetMathEqution(MathOperation mathOperation,Difficultylevel difficultylevel)
        {
            int number1;
            int number2;

            //Defining a Random Number Generator Class
            Random randomNumber= new Random();
            if (difficultylevel == Difficultylevel.Easy)
            {
                switch (mathOperation)
                {
                    case MathOperation.Addition:
                        number1 =  randomNumber.Next(10);
                        number2 = randomNumber.Next(10);
                        return ($"{number1}+{number2}", number1 + number2);
                    case MathOperation.Subtraction:
                        number1 = randomNumber.Next(10);
                        number2 = randomNumber.Next(10);
                        return ($"{number1}-{number2}", number1 - number2);
                    case MathOperation.Multiplication:
                        number1 = randomNumber.Next(10);
                        number2 = randomNumber.Next(10);
                        return ($"{number1}*{number2}", number1 * number2);
                    default:
                        throw new Exception();
                }

            }
            else if(difficultylevel==Difficultylevel.Normal)
            {
                switch (mathOperation)
                {
                    case MathOperation.Addition:
                        number1 = randomNumber.Next(100);
                        number2 = randomNumber.Next(100);
                        return ($"{number1}+{number2}", number1 + number2);
                    case MathOperation.Subtraction:
                        number1 = randomNumber.Next(100);
                        number2 = randomNumber.Next(100);
                        return ($"{number1}-{number2}", number1 - number2);
                    case MathOperation.Multiplication:
                        number1 = randomNumber.Next(100);
                        number2 = randomNumber.Next(100);
                        return ($"{number1}*{number2}", number1 * number2);
                    default:
                        throw new Exception();
                }
            }
            else 
            {
                switch (mathOperation)
                {
                    case MathOperation.Addition:
                        number1 = randomNumber.Next(1000);
                        number2 = randomNumber.Next(1000);
                        return ($"{number1}+{number2}", number1 + number2);
                    case MathOperation.Subtraction:
                        number1 = randomNumber.Next(1000);
                        number2 = randomNumber.Next(1000);
                        return ($"{number1}-{number2}", number1 - number2);
                    case MathOperation.Multiplication:
                        number1 = randomNumber.Next(1000);
                        number2 = randomNumber.Next(1000);
                        return ($"{number1}*{number2}", number1 * number2);
                    default:
                        throw new Exception();
                }
            }

        }
        public class OperationScore
        {
            public int AdditionQuestion { get; set; }
            public int AdditionScore {  get; set; }
            public int SubtractionQuestion { get; set; }
            public int SubtractionScore {  get; set; }
            public int MultiplicationQuestion { get; set; }
            public int MultiplicationScore {  get; set; }
        }
        public static OperationScore Score()
        {
            return new OperationScore();
        }
        public static(int, OperationScore,OperationScore)  RunTest(int numberOfQuestionsLeft, Difficultylevel difficultylevel)
        {
            int totalScore = 0;
            Random randomNumber= new Random();
            var (OperationMin, OperationMax) = GetPossibleOperationsByDifficulty(difficultylevel);
            var score = Score();
            var Question = Score();
            while(numberOfQuestionsLeft > 0)
            {
                int randommathoperation = randomNumber.Next(OperationMin, OperationMax);
                MathOperation mathOperation = (MathOperation)randommathoperation;
                var (message, correctAnswer) = GetMathEqution(mathOperation, difficultylevel);
                if (randommathoperation == 4 || randommathoperation == 6)
                {
                    Console.Write($"To the nearest integer, What is {message} =");
                }
                else
                {
                    Console.Write($"What is {message} =");
                }
                double userAnswer=Convert.ToDouble(Console.ReadLine());
                
                if (Math.Round(correctAnswer) == userAnswer)
                {
                    Console.WriteLine("Well Done!");
                    switch (mathOperation)
                    {
                        case MathOperation.Addition:
                            Question.AdditionQuestion++;
                            score.AdditionScore++;
                            break;
                        case MathOperation.Subtraction:
                            Question.SubtractionQuestion++;
                            score.SubtractionScore++; 
                            break;
                        case MathOperation.Multiplication: 
                            Question.MultiplicationQuestion++;
                            score.MultiplicationScore++;
                            break;

                    }
                    totalScore++;
                }
                else
                {
                    Console.WriteLine("Your Answer is Incorrect");
                    switch (mathOperation)
                    {
                        case MathOperation.Addition:
                            Question.AdditionQuestion++;
                            break;
                        case MathOperation.Subtraction:
                            Question.SubtractionQuestion++;
                            break;
                        case MathOperation.Multiplication:
                            Question.MultiplicationQuestion++;
                            break;
                        default:
                            throw new Exception();
                    }
                }
                numberOfQuestionsLeft--;
            }
            return (totalScore, score, Question);
        }

        public static void Main(String[] args)
        {
            Console.WriteLine("************* Created By Developer *************");
            Console.WriteLine("Enter your Name");
            string name=Console.ReadLine();
            Console.WriteLine("Enter your Roll_Id");
            string roll_Id = Console.ReadLine();
            Console.WriteLine("Enter your Program");
            string program=Console.ReadLine();
            Dictionary<string, Difficultylevel> difficultydictionary = new Dictionary<string, Difficultylevel>();

            difficultydictionary.Add("E", Difficultylevel.Easy);
            difficultydictionary.Add("N", Difficultylevel.Normal);
            difficultydictionary.Add("H", Difficultylevel.Hard);

            string userInputDifficulty = "";
            do
            {
                Console.WriteLine("What is the difficulty level would you like to do!Please Enter E for Easy, N for Normal , and H for Hard ");
                userInputDifficulty = Console.ReadLine();
            } while (userInputDifficulty != "E" && userInputDifficulty != "N" && userInputDifficulty != "H");

            Difficultylevel difficultylevel = difficultydictionary[userInputDifficulty];

            int numberofQuestion = 0;

            do
            {
                Console.WriteLine("How many Question Would you like to answer? Please Minimum limit is 5!");
                int.TryParse(Console.ReadLine(), out numberofQuestion);
            } while (numberofQuestion < 5);



            var (totalScore, score, Question) = RunTest(numberofQuestion, difficultylevel);
           

            if (difficultylevel == Difficultylevel.Easy)
            {
                Console.WriteLine("*********************** Result *******************************");
                Console.WriteLine("Your Name is:- " + name);
                Console.WriteLine("Your Program is:- " + program);
                Console.WriteLine("You Roll_Id is:- " + roll_Id);
                Console.WriteLine($" Total Score: {totalScore} of {numberofQuestion}");
                Console.WriteLine($"Addition Score: {score.AdditionScore} of {Question.AdditionQuestion}");    
                Console.WriteLine($"Subtraction Score: {score.SubtractionScore} of {Question.SubtractionQuestion}");    
                Console.WriteLine($"Multiplication Score: {score.MultiplicationScore} of {Question.MultiplicationQuestion}");
                Console.ReadLine();
            }

            else if (difficultylevel == Difficultylevel.Normal)
            {
                Console.WriteLine("*********************** Result *******************************");
                Console.WriteLine("Your Name is:- " + name);
                Console.WriteLine("Your Program is:- " + program);
                Console.WriteLine("You Roll_Id is:- " + roll_Id);
                Console.WriteLine($" Total Score: {totalScore} of {numberofQuestion}");
                Console.WriteLine($"Addition Score: {score.AdditionScore} of {Question.AdditionQuestion}");
                Console.WriteLine($"Subtraction Score: {score.SubtractionScore} of {Question.SubtractionQuestion}");
                Console.WriteLine($"Multiplication Score: {score.MultiplicationScore} of {Question.MultiplicationQuestion}");
                Console.ReadLine();
            }

            else 
            {
                Console.WriteLine("*********************** Result *******************************");
                Console.WriteLine("Your Name is:- " + name);
                Console.WriteLine("Your Program is:- " + program);
                Console.WriteLine("You Roll_Id is:- " + roll_Id);
                Console.WriteLine($" Total Score: {totalScore} of {numberofQuestion}");
                Console.WriteLine($"Addition Score: {score.AdditionScore} of {Question.AdditionQuestion}");
                Console.WriteLine($"Subtraction Score: {score.SubtractionScore} of {Question.SubtractionQuestion}");
                Console.WriteLine($"Multiplication Score: {score.MultiplicationScore} of {Question.MultiplicationQuestion}");
                Console.ReadLine();
            }
        }
    }
}
  