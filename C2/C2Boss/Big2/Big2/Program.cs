// See https://aka.ms/new-console-template for more information
using System.Text;
using Big2;
using Big2.Handlers;
using Big2.Models;
using Big2.Strategies.AI;
using Big2.Strategies.CardCompare;

Console.InputEncoding = Encoding.UTF8;

var deckData = Console.In.ReadLine() ?? string.Empty;
var player1 = Console.In.ReadLine() ?? string.Empty;
var player2 = Console.In.ReadLine() ?? string.Empty;
var player3 = Console.In.ReadLine() ?? string.Empty;
var player4 = Console.In.ReadLine() ?? string.Empty;

var deck = Deck.TestProkerCards(deckData);
var players = new List<Player>
{
    new AIPlayer(player1, new ConsoleInAIStrategy()),
    new AIPlayer(player2, new ConsoleInAIStrategy()),
    new AIPlayer(player3, new ConsoleInAIStrategy()),
    new AIPlayer(player4, new ConsoleInAIStrategy()),
};

var big2Game = new Big2Game(deck, players,
    new SingleHandler(new MaxCardCompareStrategy(),
        new PairHandler(new MaxCardCompareStrategy(),
            new StraightHandler(new MaxCardCompareStrategy(),
                new FullHouseHandler(new FullHouseCompareStrategy(), null)))));

big2Game.Start();

Console.ReadLine();