using Big2.Base;

namespace Big2.Models
{
    public class Big2Game : BaseGame<PokerCard>
    {
        private readonly Queue<string> _commands = new Queue<string>();

        private (Player, IList<Card>) _topCards = (null, new List<Card>());

        public Big2Game(string initCommand)
        {
            this.deck = new Deck<PokerCard>();

            var commands = initCommand.Split("\r\n").ToList();

            this.deck = new Deck<PokerCard>();
            foreach (var command in commands[0].Split(" "))
            {
                this.deck.Cards.Push(new PokerCard(command));
            }

            var players = new List<Player>();
            for (int i = 1; i <= 4; i++)
            {
                var player = new RealPlayer();
                player.Namehimself(commands[i]);

                players.Add(player);
            }

            base.JoinPlayers(players);

            commands.RemoveRange(0, 5);

            this._commands.Clear();

            foreach (var command in commands)
            {
                this._commands.Enqueue(command);
            }
        }

        public override void DrawCard()
        {
            var addIndex = 0;
            while ((this.deck.Cards.Count / players.Count) > 0)
            {
                foreach (var player in players)
                {
                    var hand = player.Hand;
                    var card = this.deck.Cards.Pop();

                    if (card.Number == 0)
                    {
                        addIndex = 4 - player.Order;
                    }

                    hand.Cards.Add(card);
                }
            }

            //Console.WriteLine(addIndex);

            foreach (var player in players)
            {
                player.Order = (player.Order + addIndex) % 4;

                var hand = player.Hand;
                hand.Cards = hand.Cards.OrderBy(c => ((PokerCard)c).Rank.Number).ThenBy(c => ((PokerCard)c).Suit.Number).ToList();
            }

            this.players = this.players.OrderBy(p => p.Order).ToList();
        }

        public override bool TakesATurn()
        {
            this.round++;
            Console.WriteLine("新的回合開始了。");

            while (Take()) ;

            if (this.players.Any(p => !p.Hand.Cards.Any()))
            {
                return false;
            }

            return true;
        }

        public bool Take()
        {
            foreach (var player in this.players)
            {
                if (_topCards.Item1 == player)
                {
                    _topCards.Item1 = null;
                    _topCards.Item2 = new List<Card>();

                    var addIndex = 4 - player.Order;
                    foreach (var player1 in players)
                    {
                        player1.Order = (player1.Order + addIndex) % 4;
                    }

                    this.players = this.players.OrderBy(p => p.Order).ToList();

                    return false;
                }

                Console.WriteLine($"輪到{player.Name}了");

                Temp(player);

                if (!player.Hand.Cards.Any())
                {

                    return false;
                }

            }

            return true;
        }

        public void Temp(Player player)
        {
            var cardsText = player.Hand.Cards.Select((c, i) =>
            {
                return new { index = i, Card = c.ToString() };
            });

            Console.WriteLine(string.Join(" ", cardsText.Select(c => $"{c.index,-4}")));
            Console.WriteLine(string.Join(" ", cardsText.Select(c => $"{c.Card,-4}")));

            if (this._commands.Any())
            {
                var cards = player.Play(this._commands.Dequeue());
                var result = true;
                var isCheck = true;
                if (cards.Any() && _topCards.Item2.Any())
                {
                    var card1 = (PokerCard)cards.OrderByDescending(c => c.Number).FirstOrDefault();
                    var card2 = (PokerCard)_topCards.Item2.OrderByDescending(c => c.Number).FirstOrDefault();
                    isCheck = (card1.Rank.Number > card2.Rank.Number) || (card1.Rank.Number == card2.Rank.Number && card1.Suit.Number >= card2.Suit.Number);
                }

                if (!_topCards.Item2.Any() && !cards.Any())
                {
                    result = false;
                    Console.WriteLine($"你不能在新的回合中喊 PASS");
                }
                else if (!cards.Any())
                {
                    Console.WriteLine($"玩家 {player.Name} PASS.");
                }
                else if ((!_topCards.Item2.Any() || _topCards.Item2.Count == 1) && cards.Count == 1 && isCheck)
                {
                    _topCards.Item1 = player;
                    _topCards.Item2 = cards;
                    Console.WriteLine($"玩家 {player.Name} 打出了 單張 {cards[0]}");
                }
                else if ((!_topCards.Item2.Any() || _topCards.Item2.Count == 2) && cards.Count == 2 && isCheck)
                {
                    _topCards.Item1 = player;
                    _topCards.Item2 = cards;
                    Console.WriteLine($"玩家 {player.Name} 打出了 對子 {cards[0]} {cards[1]}");
                }
                else if ((!_topCards.Item2.Any() || _topCards.Item2.Count == 5) && cards.Count == 5)
                {
                    var cardArray = new int[13];
                    foreach (var card in cards)
                    {
                        var pokerCard = (PokerCard)card;
                        cardArray[pokerCard.Rank.Number]++;
                    }

                    if (cardArray.Count(c => c > 0) == 2)
                    {
                        _topCards.Item1 = player;
                        _topCards.Item2 = cards;
                        Console.WriteLine($"玩家 {player.Name} 打出了 葫蘆 {cards[0]} {cards[1]} {cards[2]} {cards[3]} {cards[4]}");
                    }
                    else if (cardArray.Count(c => c > 0) == 5)
                    {
                        _topCards.Item1 = player;
                        _topCards.Item2 = cards;
                        Console.WriteLine($"玩家 {player.Name} 打出了 順子 {cards[0]} {cards[1]} {cards[2]} {cards[3]} {cards[4]}");
                    }
                }
                else
                {
                    result = false;
                    Console.WriteLine($"此牌型不合法，請再嘗試一次。");
                }

                if (!result)
                {
                    Temp(player);
                }
                else
                {
                    foreach (var card in cards)
                    {
                        player.Hand.Cards.Remove(card);
                    }
                }
            }
        }

        public override void Finish()
        {
            var winner = this.players.SingleOrDefault(p => !p.Hand.Cards.Any());

            Console.WriteLine($"遊戲結束，遊戲的勝利者為 {winner.Name}");
        }
    }
}
