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
while (true)
{
    Console.WriteLine("1-Play, 2-Rules, 3-Ladder, 4-END");
    string menu = Console.ReadLine();
    if (menu == "1")
    {
        InitGame();
    }else if(menu == "2")
    {
        Console.WriteLine("Rules. Blackjack hands are scored by their point total.\nThe hand with the highest total wins as long as it doesn't exceed 21;\na hand with a higher total than 21 is said to bust.\nCards 2 through 10 are worth their face value, and face cards (jack, queen, king)\nare also worth 10.");
    }else if(menu == "3")
    {
        var game = new Game();
        game.Ladder();
    }
    else if(menu == "4")
    {
        System.Environment.Exit(1);
    }
}
