// See https://aka.ms/new-console-template for more information
using System.Text;
using Big2;
using Big2.Handlers;
using Big2.Models;
using Big2.Strategies;

Console.InputEncoding = Encoding.UTF8;

var deckData = Console.In.ReadLine();
var player1 = Console.In.ReadLine();
var player2 = Console.In.ReadLine();
var player3 = Console.In.ReadLine();
var player4 = Console.In.ReadLine();

var deck = Deck.TestProkerCards(deckData);
var players = new List<Player>
{
    new AIPlayer(player1, new CommandAIStrategy()),
    new AIPlayer(player2, new CommandAIStrategy()),
    new AIPlayer(player3, new CommandAIStrategy()),
    new AIPlayer(player4, new CommandAIStrategy()),
};

var big2Game = new Big2Game(deck, players,
    new SingleHandler(new MaxCardCompareStrategy(),
        new PairHandler(new MaxCardCompareStrategy(),
            new StraightHandler(new MaxCardCompareStrategy(),
                new FullHouseHandler(new FullHouseCompareStrategy(), null)))));

big2Game.Start();

Console.ReadLine();