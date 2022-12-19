using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        private string _name;
        private int _value;


        private string[] _names = new string[] { "2", "3", "4", "5", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public string Name
        {
            get => _name;
            protected set
            {
                _name = value;
            }
        }

        public int Value { get => _value; }

        public Card(string name)
        {
            Name = name;

            int value;
            try
            {
                value = Int32.Parse(name);
            }
            catch
            {
                if (name == "J" || name == "Q" || name == "K")
                    value = 10;
                else
                {
                    value = 11;
                }

            }

            _value = value;

        }


        //kopírovaní pro hráče
        public Card(Card card) : this(card.Name)
        {

        }
    }

}
