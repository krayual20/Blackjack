using Blackjack;
using System.Numerics;


void InitGame()
{

    var deck = new Deck();
    var dealer = new Dealer() { Name = "Dealer" };

    Player player1;
    while (true)
    {
        Console.WriteLine("Write name: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
            Console.WriteLine("error name");
        else
        {
            player1 = new Player() { Name = name };
            break;
        }

    }
    
    var game = new Game();


    game.StartRound(deck, dealer, new Player[] {player1});

}

InitGame();

//STOP
Console.Write("click Enter, for close");
Console.ReadLine();
