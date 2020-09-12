using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nMind.DataModel;

namespace nMind
{
    public class MapViewModel
    {
        List<Node> _nodes = new List<Node>();

        public void Add(Node node)
        {
            _nodes.Add(node);
        }
    }
}
