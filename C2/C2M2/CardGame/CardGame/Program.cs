// See https://aka.ms/new-console-template for more information
using System.Text;
using CardGame.Models;
using CardGame.Showdown;
using CardGame.UNo;

Console.OutputEncoding = Encoding.UTF8;

var players = new Player[4]
{
    new AIPlayer(),
    new AIPlayer(new HomogeneityAIStrategy()),
    new AIPlayer(new HomogeneityAIStrategy()),
    new AIPlayer(),
};

var pokerCards = PokerCard.Standard52PokerCards();
var pokerDeck = new Deck(pokerCards);
var showdownGame = new ShowdownGame(pokerDeck, players);
showdownGame.Start();

Console.WriteLine("================================================");

var uNoCards = UNoCard.Standard40UNoCards();
var uNoDeck = new Deck(uNoCards);
var uNoGame = new UNoGame(uNoDeck, players);
uNoGame.Start();

