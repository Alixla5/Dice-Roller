using System;

class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        int sides = 0; // Initialize sides variable

        bool validInput = false;
        do
        {
            sides = GetUserInput("Enter the number of sides for a pair of dice: ");
            if (sides <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
            }
            else
            {
                validInput = true;
            }
        } while (!validInput);

        bool playAgain;
        do
        {
            if (sides > 0) // Ensure sides is positive before rolling the dice
            {
                int dice1 = RollDice(sides);
                int dice2 = RollDice(sides);

                Console.WriteLine($"Dice 1: {dice1}");
                Console.WriteLine($"Dice 2: {dice2}");

                int total = dice1 + dice2;

                string combination = GetCombination(dice1, dice2);
                if (!string.IsNullOrEmpty(combination))
                    Console.WriteLine($"Combination: {combination}");

                string result = GetResult(total);
                if (!string.IsNullOrEmpty(result))
                    Console.WriteLine($"Result: {result}");
            }
            else
            {
                Console.WriteLine("Invalid number of sides for the dice. Please restart the application.");
                break;
            }

            playAgain = GetUserInput("Roll again? (Y/N): ").ToString().ToUpper() == "Y";
        } while (playAgain);
    }

    static int GetUserInput(string message)
    {
        int userInput;
        while (true)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out userInput) || userInput <= 0)
                Console.WriteLine("Please enter a positive integer.");
            else
                break;
        }
        return userInput;
    }

    static int RollDice(int sides)
    {
        return random.Next(1, sides + 1);
    }

    static string GetCombination(int dice1, int dice2)
    {
        if (dice1 == 1 && dice2 == 1)
            return "Snake Eyes";
        else if ((dice1 == 1 && dice2 == 2) || (dice1 == 2 && dice2 == 1))
            return "Ace Deuce";
        else if (dice1 == 6 && dice2 == 6)
            return "Box Cars";
        else
            return "";
    }

    static string GetResult(int total)
    {
        if (total == 7 || total == 11)
            return "Win";
        else if (total == 2 || total == 3 || total == 12)
            return "Craps";
        else
            return "";
    }
}
