using Blackjack;



var dealer = new Dealer(); ;
var player = new Player();
var deck = new Deck();




dealer.TakeCard(deck.TakeCard());
dealer.TakeCard(deck.TakeCard());

player.TakeCard(deck.TakeCard());
player.TakeCard(deck.TakeCard());

var bankFlag = false;
var playerFlag = false;
while (true)
{
    if (!bankFlag)
    {
        if(dealer.Score >= 15)
        {
            bankFlag = true;
        }
        else
        {
            dealer.TakeCard(deck.TakeCard());
        }
    }

    if(!playerFlag)
    {
        Console.WriteLine($"Total: {player.Score}\nTake another card? [1-yes 2-no]");
        var choose = Console.ReadLine();
        if (choose == "1")
            player.TakeCard(deck.TakeCard());
        else if (choose == "2") 
            playerFlag = true;
        else
        {
            Console.WriteLine("Error");
        }
    }


    if (bankFlag && playerFlag)
        break;
}

if(dealer.Score == player.Score)
{
    Console.WriteLine("Draw");
}
else
{
    if (dealer.Score <= 21)
    {
        if(player.Score > 21)
            Console.WriteLine("dealer Winner");
        else
        {
            if (dealer.Score > player.Score)
            Console.WriteLine("dealer Winner");
        else
            Console.WriteLine("Player Winner");
        }
    }
    else
    {
        if (dealer.Score > player.Score)
            Console.WriteLine("Player Winner");
        else
            Console.WriteLine("dealer Winner");
    }
}

Console.WriteLine($"bank: {dealer.Score}\nplayer: {player.Score}");

//STOP
Console.Write("click Enter, for close");
Console.ReadLine();
