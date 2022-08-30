using Big2.Enums;
using Big2.Extensions;
using Big2.Handlers;
using Big2.Models;

namespace Big2
{
    public class Big2Game
    {
        private int _drawNumber = 13;

        private Deck _deck;

        private IList<Player> _players;

        private int _playPlayerIndex = 0;

        private bool _nextRound = true;

        private CardHandler _cardHandler;

        public int Round { get; private set; } = 1;

        public TopPlay TopPlay { get; private set; } = new TopPlay();

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

            while (this._nextRound)
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

            _playPlayerIndex = _players.Single(p => p.Hand.ContainClubsThree()).Index;
        }

        private void TakeRound()
        {
            while (true)
            {
                var player = _players[_playPlayerIndex];

                if (TopPlay.Player.Equals(player))
                {
                    TopPlay.ResetTopPlay();
                    break;
                }
                else
                {
                    _playPlayerIndex = (_playPlayerIndex + 1) % _players.Count;
                }

                Console.WriteLine($"輪到{player.Name}了");

                Play(player);

                if (player.Hand.Count == 0)
                {
                    _nextRound = false;
                    break;
                }
            }
        }

        private void Play(Player player)
        {
            Console.WriteLine(player.Hand.ShowAllCard());
            var cards = player.Play();

            if (cards.Any())
            {
                var pattern = this._cardHandler.Excute(TopPlay, cards);

                if (pattern == Pattern.Illegal)
                {
                    Console.WriteLine($"此牌型不合法，請再嘗試一次。");

                    Play(player);
                }
                else
                {
                    Console.WriteLine($"玩家 {player.Name} 打出了 {pattern.GetDisplayName()} {string.Join(" ", cards)}");

                    player.Hand.RemoveCard(cards);

                    TopPlay.SetTopPlay(player, cards, pattern);
                }
            }
            else if (!TopPlay.Cards.Any())
            {
                Console.WriteLine($"你不能在新的回合中喊 PASS");

                Play(player);
            }
            else
            {
                Console.WriteLine($"玩家 {player.Name} PASS.");
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