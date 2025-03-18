using System;

namespace GuessNumberGame
{
    public class NumberGame
    {
        private readonly int _targetNumber;
        private int _attempts;

        public NumberGame()
        {
            Random random = new Random();
            _targetNumber = random.Next(1, 101);
            _attempts = 0;
        }

        public int Attempts => _attempts;
        public bool IsGameWon { get; private set; }

        public string MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                return "Число має бути від 1 до 100!";
            }

            _attempts++;

            if (guess == _targetNumber)
            {
                IsGameWon = true;
                return $"Вітаємо! Ви вгадали число {_targetNumber} за {_attempts} спроб!";
            }

            return guess < _targetNumber
                ? "Загадане число більше!"
                : "Загадане число менше!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ласкаво просимо до гри 'Вгадай число'!");
            Console.WriteLine("Спробуйте вгадати число від 1 до 100.");

            var game = new NumberGame();

            while (!game.IsGameWon)
            {
                Console.Write("Введіть ваше число: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Будь ласка, введіть коректне число!");
                    continue;
                }

                string result = game.MakeGuess(guess);
                Console.WriteLine(result);
            }
        }
    }
}
