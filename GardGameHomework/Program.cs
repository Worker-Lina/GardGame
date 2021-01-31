using System;
using System.Collections.Generic;
using ConsoleMenu;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = { "Начать игру", "Правила игры", "Выход" };
            var menu = new Menu(items);
            string choice;
            do
            {
                Console.Clear();
                menu.Print();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите количество играков");
                            int countOfGamer = int.Parse(Console.ReadLine());
                            var game = new Game(new List<Player>(), new List<Karta>(), countOfGamer);
                            for (int i = 0; i < countOfGamer; i++)
                            {
                                Console.Write($"Введите имя игрока № {i + 1} ");
                                game.Players.Add(new Player(Console.ReadLine()));
                            }
                            game.DeckOfCardsForm();
                            game.ShuffleCards();
                            game.DistributionOfCards(countOfGamer);


                            while(game.Players.Count != 1)
                            {
                                var gamerKarts = new List<Karta>();
                                for (int i = 0; i < game.Players.Count; i++)
                                {
                                    if(game.Players[i].PlayearKarts.Count == 0)
                                    {
                                        game.Players.Remove(game.Players[i]);
                                    }
                                    else
                                    {
                                        gamerKarts.Add(game.Players[i].TakeCards());
                                    }                                    
                                }
                                for (int i = 0; i < gamerKarts.Count; i++)
                                {
                                    game.Players[game.BiggestCard(gamerKarts)].PlayearKarts.Add(gamerKarts[i]);
                                }
                            }
                            Console.WriteLine("-------------------------");
                            Console.WriteLine($"Победитель: {game.Players[0].Name}");

                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine(" Игровой процесс. Принцип: Игроки кладут по одной карте. У кого карта больше, то тот игрок забирает " +
                                "все карты\n и кладет их в конец своей колоды. Упрощение: при совпадении карт забирает первый игрок, шестерка не забирает\n туза." +
                                " Выигрывает игрок, который забрал все карты.");
                        }
                        break;
                    case "3":
                        break;
                }
                Console.ReadKey();
            } while (choice != "3");


        }
    }
}
