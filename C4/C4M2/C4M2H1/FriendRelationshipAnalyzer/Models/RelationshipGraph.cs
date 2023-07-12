using FriendRelationshipAnalyzer.Interfaces;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;

namespace FriendRelationshipAnalyzer.Models
{
    internal class RelationshipGraph : IRelationshipGraph
    {
        private readonly Graph<string> _graph = new(false);

        public RelationshipGraph(string script)
        {
            foreach (var item in script.Split("\r\n"))
            {
                var key = item.Split(" -- ");

                var vertex1 = _graph.GetVertex(key[0]) ?? _graph.AddVertex(key[0]);
                var vertex2 = _graph.GetVertex(key[1]) ?? _graph.AddVertex(key[1]);

                _graph.AddEdge(vertex1, vertex2);
            }
        }

        public bool HasConnection(string name1, string name2)
        {
            var vertex1 = _graph.GetVertex(name1);
            var vertex2 = _graph.GetVertex(name2);

            var countingVisitor = new CountingVisitor<Vertex<string>>();
            var orderedVisitor = new PreOrderVisitor<Vertex<string>>(countingVisitor);

            _graph.DepthFirstTraversal(orderedVisitor, vertex1);

            var visitor = new TrackingVisitor<Vertex<string>>();
            _graph.BreadthFirstTraversal(visitor, vertex1);

            return visitor.TrackingList.Contains(vertex2);
        }
    }
}