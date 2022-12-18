using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
        public void StartRound(Deck deck, Dealer dealer, Player[] players)
        {
            TakeCards(deck, dealer, players);
            CalculateResults(dealer, players);
        }

        //ostatni void = private, automaticky :)
        void AllTakeCards(int count, Deck deck, Dealer dealer, Player[] players)
        {
            for (var j = 0; j < players.Length; j++)
            {
                for (var i = 0; i < count; i++)
                {
                    players[j].TakeCard(deck.TakeCard());
                }
            }
            for (var i = 0; i < 2; i++)
            {
                dealer.TakeCard(deck.TakeCard());
            }
        }


        bool[] InitFlags(int count)
        {
            var playerFlag = new bool[count];
            for (var i = 0; i < playerFlag.Length; i++)
                playerFlag[i] = false;
            return playerFlag;


        }

        bool CheakFlags(bool[] playerFlag)
        {
            var flag = true;
            for (var i = 0; i < playerFlag.Length; i++)
            {
                flag &= playerFlag[i];//true && true = true, true && false = false :)
            }
            return flag;
        }

        void DealerTurn(Deck deck, Dealer dealer, bool dealerFlag)
        {
            if (dealer.Score >= 15)
            {
                dealerFlag = true;
            }
            else
            {
                dealer.TakeCard(deck.TakeCard());
            }
        }

        void PlayerTurn(Deck deck, Player[] players, bool[] playerFlag)
        {
            for (var i = 0; i < playerFlag.Length; i++)
            {
                if (!playerFlag[i])
                {
                    while (true)
                    {
                        Console.WriteLine($"Name: {players[i].Name}\nTotal: {players[i].Score}\nTake another card? [1-yes 2-no]");
                        var choose = Console.ReadLine();
                        if (choose == "1")
                            players[i].TakeCard(deck.TakeCard());
                        else if (choose == "2")
                        {
                            playerFlag[i] = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                }
            }
        }

        void TakeCards(Deck deck, Dealer dealer, Player[] players)
        {
            AllTakeCards(2, deck, dealer, players);


            var playerFlag = InitFlags(players.Length);
            var dealerFlag = true;

            while (dealerFlag && !CheakFlags(playerFlag))
            {
                if (!dealerFlag)
                {
                    DealerTurn(deck, dealer, dealerFlag);
                }
                else
                {
                    PlayerTurn(deck, players, playerFlag);
                }
            }
        }

        void CalculateResults(Dealer dealer, Player[] players)
        {
            for (var i = 0; i < players.Length; i++)
            {
                if (dealer.Score <= 21)
                {
                    if (players[i].Score > 21)
                        Console.WriteLine("dealer Winner");
                    else
                    {
                        if (dealer.Score > players[i].Score)
                            Console.WriteLine("dealer Winner");
                        else
                            Console.WriteLine($"{players[i].Name} Winner");
                    }
                }
                else
                {
                    if (dealer.Score > players[i].Score)
                        Console.WriteLine($"{players[i].Name} Winner");
                    else
                        Console.WriteLine("dealer Winner");
                }
                Console.WriteLine($"{players[i].Name}: {players[i].Score}\n{dealer.Name}: {dealer.Score}");
            }
        }
    }
}
