using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Deck
    {
        private List<Card> _cards;
        private Random _rand;


        public Deck()
        {
            _cards = new List<Card>();
            _rand = new Random();
        }

        private void InitDeck()
        {
            _cards.Clear();
            for(var i = 0; i < 15; i++)
            {
                string name = i.ToString();
                if (i > 10)
                {
                    switch (i)
                    {
                        case 11:
                            name = "J";
                            break;
                        case 12:
                            name = "Q";
                            break;
                        case 13:
                            name = "K";
                            break;
                        case 14:
                            name = "A";
                            break;
                    }
                }
                _cards.Add(new Card(name));
            }
        }

        public Card TakeCard()
        {
            var index = _rand.Next(0, _cards.Count);
            Card card;
            try
            {
                card = _cards[index];
                _cards.Remove(card);
            }
            catch
            {
                InitDeck();
                return TakeCard();
            }
            return card;
        }
    }
}
