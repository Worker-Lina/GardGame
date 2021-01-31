using Enum;
using System;
using System.Collections.Generic;


namespace CardGame
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public int CountOfGamer { get; set; }
        public List<Karta> Karts { get; set; }

        public Game(List<Player> players, List<Karta> karts, int countOfGamers)
        {
            Players = players;
            Karts = karts;
            CountOfGamer = countOfGamers;
        }

        public void DeckOfCardsForm()
        {
            for(int i = 1; i <= (int)(Types.Six); i++)
            {
                for (int j = 1; j <= (int)(Suits.Clubs); j++)
                {
                    Karts.Add(new Karta((Suits)j , (Types)i));
                }
            }
        }

        public void ShuffleCards()
        {
            Random rand = new Random();

            for (int i = Karts.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                Karta tmp = Karts[j];
                Karts[j] = Karts[i];
                Karts[i] = tmp;
            }
        }

        public void DistributionOfCards(int countOfGamer)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                List<Karta> somekarts = new List<Karta>();
                for (int j = 0; j < Players[i].CountOfKart; j++)
                {
                    int rand = new Random().Next(Karts.Count);
                    somekarts.Add(Karts[rand]);
                    Karts.Remove(Karts[rand]);
                }
                Players[i].PlayearKarts = somekarts;
            }
        }


        public int BiggestCard(List<Karta> cards)
        {
            int biggestCard = 10;
            int indexPlayer = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if( (int)cards[i].Type < biggestCard)
                {
                    biggestCard = (int)cards[i].Type;
                    indexPlayer = i;
                }
            }
            return indexPlayer;
        }

    }
}
