using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    public class MapFunctions
    {
        public static List<Space> LoadSpaces() // Load space data from database, returns a list of space objects
        {
            List<Space> spaces = new List<Space>();

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SPACES", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Space space = new Space();

                            space.SpaceID = reader["SpaceID"].ToString();
                            space.Width = (int)reader["Width"];
                            space.Height = (int)reader["Height"];
                            space.IsVertical = (bool)reader["IsVertical"];
                            space.X = (int)reader["X"];
                            space.Y = (int)reader["Y"];
                            space.NodeID = (int)reader["NodeID"];

                            spaces.Add(space);
                        }
                    }

                }
            }

            return spaces;
        }

        public static List<Node> LoadNodes() // Load node data from database, returns a list of node objects (very much like loadspaces, i love databases)
        {
            List<Node> nodes = new List<Node>();

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM NODES", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Node node = new Node();

                            node.NodeId = (int)reader["NodeID"];
                            node.X = (int)reader["X"];
                            node.Y = (int)reader["Y"];

                            nodes.Add(node);
                        }
                    }

                }
            }

            return nodes;
        }

        public static List<Edge> LoadEdges() // Yet another loader method!!
        {
            List<Edge> edges = new List<Edge>();

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT EdgeID, FromNodeID, ToNodeID, Cost FROM Edges", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Edge edge = new Edge();

                            edge.EdgeId = (int)reader["EdgeID"];
                            edge.FromNodeId = (int)reader["FromNodeID"];
                            edge.ToNodeId = (int)reader["ToNodeID"];
                            edge.Cost = Convert.ToDouble(reader["Cost"]);

                            edges.Add(edge);
                        }
                    }
                }
            }

            return edges;
        }

        public static void BuildConnections(List<Node> nodes, List<Edge> edges)
        {
            foreach (Edge edge in edges) // loop through all the given edges to build their to/from node connections
            {
                Node to = null;
                Node from = null;

                foreach (Node node in nodes) // loop through all the nodes until the IDs are matching, then exit the loop
                {
                    if (edge.ToNodeId == node.NodeId)
                    {
                        to = node; // hold the value of the next node
                        break;
                    }
                }

                foreach (Node node in nodes) // same as above, but finding from instead of to
                {
                    if (edge.FromNodeId == node.NodeId)
                    {
                        from = node; // hold the value of the previous node
                        break;
                    }
                }

                if (from != null && to != null) // making sure only fully connected nodes are considered, invalid stuff will be discarded 
                {
                    edge.To = to; // connects the edge to the next node
                    from.Edges.Add(edge); // adds the valid edge to the list of edges exiting the previous node

                }

            }
        }

        public static List<Node> DijkstraPathfinding(Node start, Node end, List<Node> nodes) // Using the Dijkstra algorithm, takes a start and end node and finds the shortest path (taking cost [distance] into account, allowing for a more accurate car park map)
        {
            // making sure all the nodes have the default dijkstra values
            foreach (Node node in nodes)
            {
                node.Distance = double.MaxValue; // effectively inf
                node.Visited = false;
                node.Previous = null;
            }

            start.Distance = 0; // 0 distance from the start since.. its the start 

            bool ended = false; // turns true once all nodes have been visited, or any other exit conditions are met

            while (!ended)
            {
                Node currentNode = null;

                double smallestDistance = double.MaxValue;

                foreach (Node node in nodes)
                {
                    if (!node.Visited && node.Distance < smallestDistance) // if the node hasn't been visited, and its closer than the previous closest node
                    {
                        smallestDistance = node.Distance; // update new smallest distance
                        currentNode = node; // update current node
                    }
                }

                if (currentNode == null || currentNode == end) // no more nodes or the goal is reached
                {
                    ended = true; // exit the algorithm
                }

                if (currentNode != null)
                {
                    currentNode.Visited = true;

                    foreach (Edge edge in currentNode.Edges) // check all the edges which are branching from the current node
                    {
                        Node next = edge.To;

                        if (next.Visited) // move on to the next edge if its node has already been visited
                        {
                            continue;
                        }

                        double newDistance = currentNode.Distance + edge.Cost; // increase the distance, using the current node's distance and the length of the edge

                        if (newDistance < next.Distance)
                        {
                            next.Distance = newDistance;
                            next.Previous = currentNode;
                        }

                    }
                }

            }

            // Build shortest path
            List<Node> path = new List<Node>();
            Node pointer = end; // create a pointer value which will trace backwards along the path (end --> start)
            while (pointer != null)
            {
                path.Insert(0, pointer); // add each node at the start, which will reverse the list (start --> end)
                pointer = pointer.Previous; // move the pointer backwards
            }

            return path; // return the shortest path
        }

        public static List<Space> GetAvailableSpaces(DateTime checkTime) // Method to get available spaces given one time instant
        {
            List<Space> availableSpaces = new List<Space>();

            string getSpaces = "SELECT * FROM Spaces WHERE NOT EXISTS ( SELECT * FROM BookingInfo WHERE BookingInfo.SpaceID = Spaces.SpaceID AND BookingInfo.StartTime <= @checkTime AND BookingInfo.EndTime >= @checkTime)";

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(getSpaces, conn))
                {
                    cmd.Parameters.AddWithValue("@checkTime", checkTime);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Space space = new Space();

                            space.SpaceID = reader["SpaceID"].ToString();
                            space.X = Convert.ToInt32(reader["X"]);
                            space.Y = Convert.ToInt32(reader["Y"]);
                            space.Width = Convert.ToInt32(reader["Width"]);
                            space.Height = Convert.ToInt32(reader["Height"]);
                            space.NodeID = Convert.ToInt32(reader["NodeID"]);

                            availableSpaces.Add(space);
                        }
                    }
                }
            }

            return availableSpaces;
        }

        public static List<Space> GetAvailableSpaces(DateTime startTime, DateTime endTime) // Method to get available spaces given a time span
        {
            List<Space> availableSpaces = new List<Space>();

            string getSpaces = "SELECT * FROM Spaces WHERE NOT EXISTS ( SELECT * FROM BookingInfo WHERE BookingInfo.SpaceID = Spaces.SpaceID AND BookingInfo.StartTime < @EndTime AND BookingInfo.EndTime > @StartTime)";

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(getSpaces, conn))
                {
                    cmd.Parameters.AddWithValue("@EndTime", endTime);
                    cmd.Parameters.AddWithValue("@StartTime", startTime);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Space space = new Space();

                            space.SpaceID = reader["SpaceID"].ToString();
                            space.X = Convert.ToInt32(reader["X"]);
                            space.Y = Convert.ToInt32(reader["Y"]);
                            space.Width = Convert.ToInt32(reader["Width"]);
                            space.Height = Convert.ToInt32(reader["Height"]);
                            space.NodeID = Convert.ToInt32(reader["NodeID"]);

                            availableSpaces.Add(space);
                        }
                    }
                }
            }

            return availableSpaces;
        }

        public static void DisplaySpaceInfo(Space space, bool spaceIsAvailable) // Create a popup window to display information on a given space (must be closed before continuing)
        {
            if (space == null) { return; }

            string availability = "Occupied";
            if (spaceIsAvailable)
            {
                availability = "Available";
            }

            MessageBox.Show(

                "Space Identifier: " + space.SpaceID.ToString() + "\n" +
                "Space Status: " + availability,

                "Space Information",

                MessageBoxButtons.OK,
                MessageBoxIcon.Information

                );

        }

    }
}
