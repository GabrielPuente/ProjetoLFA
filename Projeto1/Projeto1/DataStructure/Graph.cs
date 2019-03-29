using System.Collections.Generic;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um grafo.
    /// </summary>
    public class Graph
    {

        #region Atributos

        /// <summary>
        /// Lista de nós que compõe o grafo.
        /// </summary>
        public List<Node> nodes;
        #endregion

        #region Propridades

        /// <summary>
        /// Mostra todos os nós do grafo.
        /// </summary>
        public Node[] Nodes
        {
            get { return this.nodes.ToArray(); }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do grafo.
        /// </summary>
        public Graph()
        {
            this.nodes = new List<Node>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Encontra o nó através do seu nome.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <returns>O nó encontrado ou nulo caso não encontre nada.</returns>
        public Node Find(string name)
        {
            Node n = null;
            foreach (Node node in nodes)
            {
                if (node.Name == name)
                    n = node;
            }
            return n;
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name)
        {
            AddNode(name, null);
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name, object info)
        {
            nodes.Add(new Node(name, info));
        }

        /// <summary>
        /// Remove um nó do grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser removido.</param>
        public void RemoveNode(string name)
        {
            Node n = Find(name);
            if (n != null)
            {
                nodes.Remove(n);
                foreach (Node node in nodes)
                {
                    for (int i = 0; i < node.Edges.Count; i++)
                    {
                        Edge e = node.Edges[i];
                        if (e.To.Name == name)
                        {
                            node.Edges.Remove(e);
                            i--;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="from">O nó de origem.</param>
        /// <param name="to">O nó de destino.</param>
        /// <param name="cost">O cust associado.</param>
        public void AddEdge(string from, string to)
        {
            Node nFrom = Find(from);
            Node nTo = Find(to);
            if (nFrom != null && nTo != null)
            {
                nFrom.AddEdge(nTo);
            }
        }
        /// <summary>
        /// Obtem todos os nós vizinhos de determinado nó.
        /// </summary>
        /// <param name="node">O nó origem.</param>
        /// <returns></returns>
        public Node[] GetNeighbours(string from)
        {
            Node n = Find(from);
            Node[] neighbours = null;
            if (n != null)
            {
                neighbours = new Node[n.Edges.Count];
                int i = 0;
                foreach (Edge e in n.Edges)
                {
                    neighbours[i++] = e.To;
                }
            }
            return neighbours;
        }

        /// <summary>
        /// Valida um caminho, retornando a lista de nós pelos quais ele passou.
        /// </summary>
        /// <param name="nodes">A lista de nós por onde passou.</param>
        /// <param name="path">O nome de cada nó na ordem que devem ser encontrados.</param>
        /// <returns></returns>
        public bool IsValidPath(ref Node[] nodes, params string[] path)
        {
            bool valid = true;
            if (path.Length > 0)
            {
                List<Node> pathNodes = new List<Node>();
                Node n = Find(path[0]);
                if (n == null)
                    return false;
                for (int i = 1; i < path.Length; i++)
                {
                    Node[] neighbours = GetNeighbours(n.Name);
                    foreach (Node node in neighbours)
                    {
                        if (node.Name == path[i])
                            n = node;
                    }
                    if (n.Name != path[i])
                        return false;
                }
            }
            return valid;
        }

        public List<Node> BreadthFirstSearch(string begin)
        {
            Node node = Find(begin);

            if (node == null)
                return null;

            List<Node> nodes = new List<Node>();
            Queue<Node> queue = new Queue<Node>();
            VisitedZero();

            node.Visited = true;
            queue.Enqueue(node);
            nodes.Add(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                foreach (Edge edge in node.Edges)
                {
                    if (edge.To.Visited == false)
                    {
                        edge.To.Visited = true;
                        edge.To.Parent = node;
                        queue.Enqueue(edge.To);
                        nodes.Add(edge.To);
                    }
                }
            }
            return nodes;
        }

        public List<int> BreadthSearch(string begin)
        {
            Node node = Find(begin);

            if (node == null)
                return null;

            List<int> nodes = new List<int>();
            Queue<Node> queue = new Queue<Node>();
            VisitedZero();

            node.Visited = true;
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                foreach (Edge edge in node.Edges)
                {
                    if (edge.To.Visited == false)
                    {
                        edge.To.Visited = true;
                        edge.To.Parent = node;
                        queue.Enqueue(edge.To);
                    }
                }
            }
            return nodes;
        }

        public void VisitedZero()
        {
            foreach (Node node in Nodes)
            {
                node.Visited = false;
                node.Parent = null;
            }
        }
        #endregion
    }
}