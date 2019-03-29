using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2_LFA.DATA_STRUCTURE
{
    class Graph
    {
        List<Node> nodes;
        List<Edge> edges;
        int qCount = 0;
        bool isOrExpression = false;
        Node iniOr = new Node(), finOr = new Node();

        public Graph()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
            AddNode("Q0");
            this.qCount++;
        }

        public void AddNode(string name)
        {
            Node aux = new Node(name);

            if (find(name) == null)
                nodes.Add(aux);
        }

        public void AddExp(string initial, string final, string name, bool isOr)
        {
            if (isOrExpression)
            {
                isOrExpression = false;
                this.AddNode(initial);
                this.AddEdge(iniOr.Name, initial, "&");
                this.AddNode(final);
                this.AddEdge(initial, final, name);
                this.AddEdge(final, finOr.Name, "&");
            }
            else
            {
                Node aux = this.nodes.Last();
                this.AddNode(initial);
                this.AddEdge(aux.Name, initial, "&");
                this.AddNode(final);
                this.AddEdge(initial, final, name);
                this.AddNode("Q" + this.qCount);
                this.AddEdge(final, "Q" + this.qCount, "&");
                this.qCount++;
                if(isOr)
                {
                    iniOr = aux;
                    finOr = this.nodes.Last();
                    isOrExpression = true;
                }
            }
        }

        public void AddEdge(string nameFrom, string nameTo, string cost)
        {
            Node from = find(nameFrom);
            Node to = find(nameTo);

            Edge e = new Edge(from, to, cost);

            from.AddEdge(to, "");
            edges.Add(e);

        }

        public void defineFinalNode()
        {
            foreach(Node n in this.nodes)
            {
                if(n.Edges.Count == 0)
                {
                    n.isFinal = true;
                }
            }            
        }
        
        public Node find(Object info)
        {
            foreach (Node n in nodes)
            {
                if (n.Name.Equals(info))
                    return n;
            }

            return null;
        }
    }
}