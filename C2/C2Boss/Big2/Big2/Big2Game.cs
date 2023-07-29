using Big2.Enums;
using Big2.Extensions;
using Big2.Handlers;
using Big2.Models;

namespace Big2
{
    public class Big2Game
    {
        private readonly int _drawNumber = 13;

        private int _playPlayerIndex = 0;

        private bool _isNextRound = true;

        private readonly Deck _deck;

        private readonly IList<Player> _players;

        private readonly CardHandler _cardHandler;

        private TopPlay TopPlay { get; } = new TopPlay();

        public int Round { get; private set; } = 1;

        public Big2Game(Deck deck, IList<Player> players, CardHandler cardHandler)
        {
            this._deck = deck;
            this._players = players;
            this._cardHandler = cardHandler;
        }

        public void Start()
        {
            NameHimselfStage();

            ShuffleStage();

            DealStage();

            while (this._isNextRound)
            {
                Console.WriteLine($"新的回合開始了。");

                TakeRound();

                Round++;
            }

            GameOver();
        }

        private void NameHimselfStage()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].SetIndex(i);
                _players[i].NameHimself($"Player {i}");
                _players[i].SetGame(this);
            }
        }

        private void ShuffleStage()
        {
            _deck.Shuffle();
        }

        private void DealStage()
        {
            for (int i = 0; i < _drawNumber * _players.Count; i++)
            {
                if (_deck.Any())
                {
                    var index = i % _players.Count;
                    _players[index].Hand.AddCard(_deck.DrawCard());
                }
            }

            GetIndexHandContainClubsThree();
        }

        private void TakeRound()
        {
            while (true)
            {
                var player = _players[_playPlayerIndex];

                if (TopPlay.Player != null && TopPlay.Player.Equals(player))
                {
                    TopPlay.ResetTopPlay();
                    break;
                }

                Console.WriteLine($"輪到{player.Name}了");

                Play(player);

                if (player.Hand.Count == 0)
                {
                    _isNextRound = false;
                    break;
                }
            }
        }

        private void GetIndexHandContainClubsThree()
        {
            var card = new Card(Suit.Club, Rank.Three);

            _playPlayerIndex = _players
                .Single(p => p.Hand.ContainsCard(card))
                .Index;
        }

        private void Play(Player player)
        {
            while (_playPlayerIndex == player.Index)
            {
                Console.WriteLine(player.Hand.ShowAllCard());
                var cards = player.Play();

                try
                {
                    if (!cards.Any() && !TopPlay.Cards.Any())
                    {
                        throw new NewRoundMustNotPassException();
                    }

                    if (cards.Any())
                    {
                        var pattern = this._cardHandler.Excute(TopPlay, cards);

                        Console.WriteLine($"玩家 {player.Name} 打出了 {pattern.GetDisplayName()} {string.Join(" ", cards)}");

                        player.Hand.RemoveCard(cards);

                        TopPlay.SetTopPlay(player, cards, pattern);
                    }
                    else
                    {
                        Console.WriteLine($"玩家 {player.Name} PASS.");
                    }

                    _playPlayerIndex = (_playPlayerIndex + 1) % _players.Count;
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private Player? WinnerPlayer()
        {
            return this._players.SingleOrDefault(p => p.Hand.Count == 0);
        }

        private void GameOver()
        {
            Console.WriteLine($"遊戲結束，遊戲的勝利者為 {this.WinnerPlayer()?.Name}");
        }
    }
}