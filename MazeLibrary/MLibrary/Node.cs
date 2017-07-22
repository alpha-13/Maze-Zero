using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLibrary
{
    public class Node
    {
        public Node Parent;

        public Node(Node Parent)
        {
            this.Parent = Parent;
        }

        public List<Node> Children { set; get; }

        public Directions Direction { set; get; }

        public int PointX { set; get; }

        public int PointY { set; get; }

        public bool IsGoal = false;

        public bool? [,] State { set; get; }

    }
}
