﻿using FriendRelationshipAnalyzer.Interfaces;
using FriendRelationshipAnalyzer.Models;

namespace FriendRelationshipAnalyzer
{
    internal class RelationshipAnalyzerAdapter : IRelationshipAnalyzer, IRelationshipGraph
    {
        private readonly Dictionary<string, List<string>> _friendsData = new();

        private readonly SuperRelationshipAnalyzer _superRelationshipAnalyzer = new();

        private IRelationshipGraph? _relationshipGraph;

        public void Parse(string script)
        {
            var superData = new List<string>();

            foreach (var item in script.Split("\r\n"))
            {
                var key = item.Split(':');
                _friendsData[key[0]] = key[1].Trim().Split(" ").ToList();

                foreach (var value in _friendsData[key[0]])
                {
                    if (!superData.Contains($"{value} -- {key[0]}"))
                    {
                        superData.Add($"{key[0]} -- {value}");
                    }
                }
            }

            _superRelationshipAnalyzer.Init(string.Join("\r\n", superData));
            _relationshipGraph = new RelationshipGraphAdapter(string.Join("\r\n", superData));
        }

        public IEnumerable<string> GetMutualFriends(string name1, string name2)
        {
            var result = new List<string>();

            var targets = _friendsData[name1]?
                .Union(_friendsData[name2])
                .Where(f => !new[] { name1, name2 }.Contains(f)) ?? new List<string>();

            foreach (var target in targets
                .Where(t => _superRelationshipAnalyzer.IsMutualFriend(t, name1, name2)))
            {
                result.Add(target);
            }

            return result;
        }

        public bool HasConnection(string name1, string name2)
        {
            return _relationshipGraph!.HasConnection(name1, name2);
        }
    }
}
