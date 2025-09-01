using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    public class Space
    {

        public string SpaceID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; } 

        public bool IsVertical { get; set; } // False = horizontal, True = vertical (spaces only need to be horiz or vert)

        public int X { get; set; } // X position on the map
        public int Y { get; set; } // Y position on the map
        public int NodeID { get; set; }

        public bool Occupied { get; set; } // Whether the space is rendered as occupied or not

        public Space() { } // If I want to assign values after creation
        public Space(string spaceID, int x, int y, int width, int height, bool isVertical, int nodeID) // For assigning all properties at creation
        {
            SpaceID = spaceID;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            IsVertical = isVertical;
            NodeID = nodeID;
        }


    }
}
