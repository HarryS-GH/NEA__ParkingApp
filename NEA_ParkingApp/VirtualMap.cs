using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_ParkingApp
{
    public partial class VirtualMap : Form
    {
        private List<Node> path = new List<Node>(); // List of nodes which will be connected visually
        private string mode = null;

        List<Space> spaces = MapFunctions.LoadSpaces();
        List<Space> availableSpaces = new List<Space>();

        Space SelectedSpace = null;

        List<Node> nodes = MapFunctions.LoadNodes();
        List<Edge> edges = MapFunctions.LoadEdges();

        Color OccupiedSpaceColor = Color.Crimson;
        Color AvailableSpaceColor = Color.Aqua;
        Color SelectedSpaceColor = Color.LightBlue;

        public VirtualMap() // Browse mode - user can freely select any space
        {
            InitializeComponent();

            mode = "Browse";

            RenderSpaces(spaces); // Place spaces onto the map

            availableSpaces = MapFunctions.GetAvailableSpaces(DateTime.Now); // Get all currently available spaces

            MapFunctions.BuildConnections(nodes, edges);

            UpdateSpaceColours();
        }

        public VirtualMap(Space highlightedSpace, List<Space> availablespaces) // Locked mode - map is read-only, with selected spaces already chosen for the user
        {
            InitializeComponent();

            mode = "Locked";

            RenderSpaces(spaces);

            availableSpaces = availablespaces; // Update list of available spaces

            MapFunctions.BuildConnections(nodes, edges);

            ComputePathToSpace(highlightedSpace);
            SelectedSpace = highlightedSpace;

            UpdateSpaceColours();

        }

        private void UpdateSpaceColours()
        {
            foreach (Control control in MapPanel.Controls)
            {
                if (control is Panel panel && panel.Tag is Space space) // Grab all the spaces with attached info
                {
                    bool spaceIsAvailable = false;

                    foreach (Space available in availableSpaces)
                    {
                        if (available.SpaceID == space.SpaceID)
                        {
                            spaceIsAvailable = true;
                            break;
                        }
                    }

                    if (space == SelectedSpace)
                    {
                        panel.BackColor = SelectedSpaceColor;
                        ComputePathToSpace(space);
                    }
                    else if (spaceIsAvailable)
                    {
                        panel.BackColor = AvailableSpaceColor;
                    }
                    else
                    {
                        panel.BackColor = OccupiedSpaceColor;
                    }
                }
            }
        }


        public void ComputePathToSpace(Space space) // Updates the path list to contain the shortest path from the entrance (node 1) to a designated space
        {
            Node startingNode = null;
            Node endNode = null;


            foreach (Node node in nodes)
            {
                Debug.WriteLine(node.NodeId);
                if (node.NodeId == 1)
                {
                    Debug.WriteLine("found 1");
                    startingNode = node; // Grab the starting node (should always have an id of 1)
                }
                else if (node.NodeId == space.NodeID)
                {
                    Debug.WriteLine("found 2");
                    endNode = node;
                }
            }


            Debug.WriteLine(startingNode.NodeId);
            Debug.WriteLine(endNode.NodeId);

            if (startingNode != null && endNode != null)
            {
                // Valid nodes found, can pathfind

                Debug.WriteLine("gonna draw now");

                path = MapFunctions.DijkstraPathfinding(startingNode, endNode, nodes);

                Debug.WriteLine($"Path count: {path.Count}");
                foreach (var n in path)
                {
                    Debug.WriteLine($"Node {n.NodeId} at ({n.X},{n.Y})");
                }


                RenderPath(); // Cause the paint function to update (redraw the path)
            }
        }

        public void RenderSpaces(List<Space> spaces)
        {
            foreach (Space space in spaces)
            {
                Panel panel = new Panel();

                panel.Width = space.Width;
                panel.Height = space.Height;

                bool spaceIsAvailable = false;

                foreach (Space available in availableSpaces)
                {
                    if (available.SpaceID == space.SpaceID)
                    {
                        spaceIsAvailable = true; // Check if space is available
                        break;
                    }
                }

                if (spaceIsAvailable) // Colour the spaces according to their availability
                {
                    panel.BackColor = AvailableSpaceColor;
                }
                else
                {
                    panel.BackColor = OccupiedSpaceColor;
                }

                if (space == SelectedSpace)
                {
                    panel.BackColor = SelectedSpaceColor;
                }



                    Point pos = new Point(space.X, space.Y); // turn x and y values into useable point location

                panel.Location = pos;

                panel.Tag = space; // Store space info in each space panel to be referenced when clicked
                panel.Click += Space_Click; // Allows each space to be clicked

                this.MapPanel.Controls.Add(panel); // Add the new space to the mapPanel

            }
        }

        private void Space_Click(object sender, EventArgs e) // Fires when a space is clicked
        {
            Panel panel = sender as Panel; // Get the panel that was clicked

            if (panel == null) { return; }

            Space space = (Space) panel.Tag; // Get relevant space info

            bool spaceIsAvailable = false;

            foreach (Space available in availableSpaces)
            {
                if (available.SpaceID == space.SpaceID)
                {
                    spaceIsAvailable = true; // Check if space is available
                    break;
                }
            }

            if (spaceIsAvailable)
            {
                
                SelectedSpace = space;
                UpdateSpaceColours();
                
            }
            else if (mode == "Locked")
            {
                return; // Don't allow unavailable spaces to be clicked in locked mode
            }

            MapFunctions.DisplaySpaceInfo(space, spaceIsAvailable);

            Debug.WriteLine(space.SpaceID);

        }

        public void RenderPath()
        {
            MapPanel.Invalidate(); // Forces the form to redraw and is resizable 
        }

        private void MapPanel_Paint(object sender, PaintEventArgs Event)
        {
            Debug.WriteLine("draw 1");
            if (path.Count < 2) { return; }
            Debug.WriteLine("draw 2");
            using (Pen pen = new Pen(Color.Blue, 15)) // Create pen object 
            {

                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round; // Alter the shape of the line so they connect in a more visually appealing way

                for (int i = 0; i < path.Count - 1; i++)
                {
                    Node drawFrom = path[i];
                    Node drawTo = path[i + 1];

                    Event.Graphics.DrawLine(pen, new Point(drawFrom.X, drawFrom.Y), new Point(drawTo.X, drawTo.Y)); // Draw a line between 2 nodes (representing an edge)

                    Debug.WriteLine("drew line");
                }
            }
        }
    }
}
