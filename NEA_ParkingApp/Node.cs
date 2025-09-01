using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    public class Node
    {
        public int NodeId { get; set; }
        public int X {  get; set; } // X position on map
        public int Y { get; set; } // Y position on map

        // values for dijkstra pathfinding
        public double Distance { get; set; } = double.MaxValue; // starts as large as possible, decreases when algorithm finds a shorter path to the node
        public Node Previous { get; set; } = null; // last node in the shortest path
        public bool Visited { get; set; } = false; // whether the node has been visited yet

        public List<Edge> Edges { get; set; } = new List<Edge>(); // Connecting edges (links to other nodes on the map)

        public Node() { } // if i want to assign values after creation

        public Node(int nodeId, int x, int y) // for assigning values at creation
        {
            NodeId = nodeId;
            X = x;
            Y = y;

        }
    }
}
