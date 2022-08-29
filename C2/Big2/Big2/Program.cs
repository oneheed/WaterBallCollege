﻿// See https://aka.ms/new-console-template for more information
using Big2;
using Big2.Handlers;
using Big2.Models;
using Big2.Strategies;

var testData = @"D[7] C[A] S[6] S[4] S[A] S[J] C[10] C[K] D[4] H[9] D[J] D[K] C[7] H[8] C[3] S[K] S[3] D[2] C[8] C[4] H[Q] C[J] D[3] D[6] D[9] D[A] H[6] S[7] H[7] C[6] H[3] C[Q] H[J] H[10] S[9] D[10] C[9] D[8] D[Q] H[5] H[K] C[5] D[5] C[2] S[10] S[5] S[Q] S[8] H[2] H[4] H[A] S[2]
水球
火球
保齡球
地瓜球
0 1 2 4 5
-1
2 3 4 5 6
8 9 10 0 1
-1
-1
-1
0
1
6
2
4
6
11
6
5
-1
-1
-1
0
1
6
2
3
-1
-1
-1
0
1
9
4
-1
-1
-1
3
-1
-1
8
-1
-1
-1
1 2
-1
-1
2 3
-1
-1
-1
0
1
2
-1
-1
-1
0
1
0";

var commands = testData.Split("\r\n").ToList();
var aiCommands = commands.Skip(5).GetEnumerator();
var deck = Deck.TestProkerCards(commands[0]);
var players = new List<Player>
{
    new AIPlayer(commands[1], new TestAIStrategy(aiCommands)),
    new AIPlayer(commands[2], new TestAIStrategy(aiCommands)),
    new AIPlayer(commands[3], new TestAIStrategy(aiCommands)),
    new AIPlayer(commands[4], new TestAIStrategy(aiCommands)),
};

var big2Game = new Big2Game(deck, players,
    new SingleHandler(
        new PairHandler(
            new StraightHandler(
                new FullHouseHandler(null)))));

big2Game.Start();