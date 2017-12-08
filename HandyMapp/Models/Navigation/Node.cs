using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyMapp.Models.Navigation
{
    public class Node : IComparable<Node>
    {
        public Node Parrent;
        public Vector Vector;
        public double FCost { get; set; }
        public double GCost { get; set; }
        public double TCost { get; set; }
        public double HCost { get; set; }

        public Node( Node parrent, Vector vector,  double tCost, double gCost, double hCost)
        {
            this.Parrent = parrent;
            this.Vector = vector;
            this.TCost = tCost;         //cost made by terain
            this.GCost = gCost;         //cost made getting here
            this.HCost = hCost;         //cost distance to finnish 
            this.FCost = gCost + hCost;    //total cost
        }

        public int CompareTo(Node other)
        {
            if (this.FCost > other.FCost)
            {
                return 1;
            }
            if (this.FCost < other.FCost)
            {
                return -1;
            }
            return 0;
        }
    }
}

