//Author: Nadiem Idrisi
//Program: Number guessing game, guess a random number while using hints to guess it in few tries.
//10/06/2023

using System;
using System.Xml.Serialization;

namespace gameCode{
    class NumberGuess{
        //random number generation
        static Random random = new Random();

        //fields
        public static int guessPassIntCheck = 0;
        public static int guessGood = 0;
        public static string userGuessString = null;
        public static string response = null;
        public static string response2 = null;
        public static bool winnerWinner = false;
        public static int goalNum = random.Next(1, 100);
        public static string primePhrase = null;
        public static int tryCount = 0;
        public static int oldGuessDelta = 0;
        public static int diffGoalGuess = 0;
        public static int coldLimit = 25;
        public static int coolLimit = 10;
        public static int warmLimit = 3;



        public static void intCheckAndConvert(string guessToConvert){
            if (int.TryParse(guessToConvert, out int convertedValue)){
                guessPassIntCheck = convertedValue;
            }
            else{
                Console.WriteLine("Invalid Guess");
            }
        }

        public static int giveHint(int goalNeedsHint){
            List<int> possibleHints = new List<int>();
            //for loop to find factors, I'm purposely letting the loop add the original goalNeedsHint as a factor to use it to find the length of the list
            for (int i = 2; i <= goalNeedsHint; i++){
                if (goalNeedsHint % i == 0){
                    possibleHints.Add(i);
                } 
                
            }
            if (possibleHints.Count == 1){
                return 0;
            }
            int randomLength = possibleHints.IndexOf(goalNeedsHint);
            int randomIndex = random.Next(0, randomLength);
            return possibleHints[randomIndex];
            Console.WriteLine(randomLength);
        }

        public static void minMaxCheck(int numToCheck){
            //makes sure guess passed int check
            if (guessPassIntCheck == 0){
                return;
            }
            if(numToCheck >= 1 || numToCheck <= 100){
                guessGood = numToCheck;
                }
            else{
                    Console.WriteLine("My number is between 1 & 100 so your's should probably be there too. Try another number!");
                }
        }

        public static void WinCheck(string gameLine){
            if(winnerWinner == true){
                Console.WriteLine("\n"+gameLine);
                Console.WriteLine("It only took you " + tryCount + " tries.");
                Console.WriteLine("Thanks for playing!");
                
            }
            else{
                Console.WriteLine(gameLine);
                Console.WriteLine("Next guess: ");

                resetValues();
            }
        }

        public static void resetValues(){
            guessPassIntCheck = 0;
            guessGood = 0;
            userGuessString = null;
        }

        public static void valueChecks(){
            //user Input
            userGuessString = Console.ReadLine();
            tryCount++;
            //check that input is an int
            NumberGuess.intCheckAndConvert(userGuessString);

            //check if guess is between min and max. If it's good then 'guessGood' now contains the guess
            NumberGuess.minMaxCheck(guessPassIntCheck);
            response = NumberGuess.howClose(guessGood, goalNum) + NumberGuess.howclose2();
            NumberGuess.WinCheck(response);
            oldGuessDelta = diffGoalGuess;
        }

        public static void primeHint(){
            if (goalNum > 66){
                primePhrase = "pretty high.";
            }
            else if (goalNum > 33){
                primePhrase = "kind of central.";
            }
            else{
                primePhrase = "pretty low.";
            }
        }
        public static string howClose(int guess, int goal){
            diffGoalGuess = Math.Abs(goal-guess);
            if (diffGoalGuess == 0){
                winnerWinner = true;
                return "\nYou got it!";
                
            }
            else if (diffGoalGuess >= coldLimit){
                return "\n Freezing Cold...";
            }
            else if (diffGoalGuess >= coolLimit){
                return "\nCool...";
            }
            else if (diffGoalGuess >= warmLimit){
                return "\nWarm...";
            }
            else {
                return "\nRed Hot...!";
            }
        }
        public static string howclose2(){
            if (oldGuessDelta == 0) {
                return " \n";
            }
            else if (oldGuessDelta < diffGoalGuess && diffGoalGuess >= coolLimit){
                return " and you're getting farther.\n";
            }
            else if (oldGuessDelta > diffGoalGuess && diffGoalGuess >= coolLimit){
                return " but you're getting closer!\n";
            }
            else if (oldGuessDelta > diffGoalGuess && diffGoalGuess >= warmLimit){
                return " and you're getting closer!\n";
            }
            else if (oldGuessDelta < diffGoalGuess && diffGoalGuess >= warmLimit){
                return " but you're getting farther.\n";
            }
            else if (oldGuessDelta == diffGoalGuess){
                return " but did you make the same guess? Either that or you overshot pretty hard.\n";
            }
            else {
                return " \n";
        }
        }
        static void Main(string[] args){
            Console.WriteLine("Let's play a guessing game!\n\n I'll choose a number between 1 and 100. Guess my number and I'll tell you how close you are.\n\n I'll also tell you ONE number that is a factor of my number. If it's prime, I'll let you know.\n\n Guess my number in as few tries as you can!");

            //hint
            int hint = NumberGuess.giveHint(goalNum);
            if (hint != 0){
                Console.WriteLine("My number is divisible by "+ hint + "!\n");
            }
            else{
                NumberGuess.primeHint();
                Console.WriteLine("My number is prime and " + primePhrase + "\n");
            }
            //user input
            
            while(winnerWinner == false){
                NumberGuess.valueChecks();
            }
        }
    }
}