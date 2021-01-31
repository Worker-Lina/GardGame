using Enum;

namespace CardGame
{
    public class Karta
    {
        public Suits Suit { get; set; }
        public Types Type { get; set; }


        public Karta()
        {

        }
        public Karta(Suits suit, Types type)
        {
            Suit = suit;
            Type = type;
        }

        public string KartInfo()
        {
            return $" {Suit}, {Type} "; 
        }

    }
}
