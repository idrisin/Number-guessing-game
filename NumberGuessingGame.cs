using System;

namespace gameCode{
    class NumberGuess{
        //random number generation
        static Random random = new Random();

        public static string howClose(int guess, int goal){
            int diff = Math.Abs(goal-guess);
            if (diff >= 35){
                return "Cold";
            }
            else if (diff >= 25){
                return "Cool";
            }
            else if (diff >= 15){
                return "Warm";
            }
            else {
                return "Hot";
            }
        }

        public static int intCheckAndConvert(string guessToConvert){
            if (int.TryParse(guessToConvert, out int convertedValue)){
                return convertedValue;
            }
            else{
                return 0;
            }
        }

        public static int giveHint(int goalNeedsHint){
            List<int> possibleHints = new List<int>();
            bool factorsExist = false;
            //for loop to find factors, I'm purposely letting the loop add the original goalNeedsHint as a factor to use it to find the length of the list
            for (int i = 1; i <= goalNeedsHint; i++){
                if (goalNeedsHint % i == 0 && i != 1){
                    possibleHints.Add(i);
                    factorsExist = true;
                } 
                
            }
            if(possibleHints.Count == 0){
                return 0;
            }
            int randomLength = possibleHints.IndexOf(goalNeedsHint);
            int randomIndex = random.Next(0, randomLength-1);
            return possibleHints[randomIndex];
            Console.WriteLine(randomLength);
        }
/*
        public static int minMaxCheck(){
            //build later
        }
*/
        static void Main(string[] args){
            Console.WriteLine("Let's play a guessing game!\n\n I'll choose a number between 1 and 100. Guess my number and I'll tell you how close you are.\n\n I'll also tell you ONE number that is a factor of my number. If it's prime, I'll let you know.\n\n Guess my number in as few tries as you can!");
            int goalNum = random.Next(1, 100);

            Console.WriteLine("goal num = " + goalNum);
            int hint = NumberGuess.giveHint(goalNum);
            if (hint != 0){
                Console.WriteLine("My number is divisible by "+ hint + "!");
            }
            else{
                Console.WriteLine("Your number is prime...");
            }
            string userGuessString = Console.ReadLine();
            if (NumberGuess.intCheckAndConvert(userGuessString) != 0)
            {
                int firstGuess = NumberGuess.intCheckAndConvert(userGuessString);
                Console.WriteLine(goalNum);
                Console.WriteLine(NumberGuess.howClose(firstGuess, goalNum));
            }
            else{
                Console.WriteLine("NO");
            }
        }
    }
}