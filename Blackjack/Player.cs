using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        private string _name = "Player1";
        private List<Card> _hand;


        //set hrace
        public string Name
        {
            get { return _name; }
            set { 
                

                //pokud vznikne chyba
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("name cannot be empty");   
                _name = value;
            }  
        }


        // copy array
        //muzu s nim delat, co chci a v mem hlavnim array se nic nesatane 
        public Card[] Hand
        {
            get 
            {
                var array = new Card[_hand.Count];
                for (var i = 0; i < _hand.Count; i++)
                {
                    array[i] = new Card(_hand[i]);
                }
                return array;
            }
        }


        public int Score
        {
            get
            {
                var sum = 0;
                for(var i = 0; i < _hand.Count; i++)
                {
                    sum += _hand[i].Value;
                }
                return sum;
            }
        }

        public Player()
        {
            _hand = new List<Card>();
        }

        public void TakeCard(Card card)
        {
            _hand.Add(card);// do ruky pridavam karty
        }

        //vycistit ruka
        public void ClearHand() => _hand.Clear();

    }
}
