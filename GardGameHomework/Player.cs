using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Karta> PlayearKarts { get; set; }
        public int CountOfKart { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void PrintKarts()
        {
            Console.WriteLine($"карты игрока {Name}");
            foreach (var card in PlayearKarts)
            {
                Console.WriteLine(card.KartInfo());
            }
            Console.WriteLine("------------------------------------");
        }

        public Karta TakeCards()
        {
            var karta = new Karta();
            int rand = new Random().Next(PlayearKarts.Count);
            karta = PlayearKarts[rand];
            PlayearKarts.Remove(karta);
            return karta;
        }
    }
}
