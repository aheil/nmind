using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        internal string Serialize()
        {
            string json = JsonConvert.SerializeObject(_nodes);
            return json;
        }
    }
}
