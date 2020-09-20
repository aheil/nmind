using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using nMind.DataModel;

namespace nMind.ViewModels
{
    public delegate void AddControlCallback(NodeViewModel nodeViewModel);

    public class MapViewModel
    {

        AddControlCallback addControllCallback;
        List<Node> _nodes = new List<Node>();

        public MapViewModel(AddControlCallback handler)
        {
            addControllCallback += handler;
        }

        private void Load(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                var nodeViewModel = new NodeViewModel(node);
                addControllCallback(nodeViewModel);
                node.Refresh();
            }
        }

        public void Add(Node node)
        {
            _nodes.Add(node);
        }

        internal string Serialize()
        {
            string json = JsonConvert.SerializeObject(_nodes);
            return json;
        }

        internal void Deserialize(string raw) 
        {
            var nodes = JsonConvert.DeserializeObject<List<Node>>(raw);

            _nodes = nodes;
            Load(nodes);
        }
    }
}
