using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    public class Edge
    {
        public int EdgeId { get; set; }
        public int FromNodeId { get; set; } // nodeid of the previous node
        public int ToNodeId { get; set; } // nodeid of the next node
        public Node To {  get; set; }
        public double Cost { get; set; } = 1; // effective length of the edge, using meters for now

        public Edge() { } // if i need to set the edge data after creation

        public Edge(int edgeId, int fromNodeId, int toNodeId, double cost)
        {
            EdgeId = edgeId;
            FromNodeId = fromNodeId;
            ToNodeId = toNodeId;
            Cost = cost;
        }
    }
}
