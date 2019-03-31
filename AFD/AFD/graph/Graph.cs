using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto2_LFA.graph
{
    public class Graph
    {
        #region Propriedades
        /// <summary>
        /// Listas de no do grafo
        /// </summary>
        public List<Node> nodes;
        /// <summary>
        /// listas de araestas
        /// </summary>
        public List<Edge> edges;
        /// <summary>
        /// Quantidade de nos
        /// </summary>
        public int qCount = 0;
        /// <summary>
        /// É operador OR
        /// </summary>
        public bool isOrExpression = false;
        /// <summary>
        /// Nó inicial
        /// </summary>
        public Node iniOr = new Node();
        /// <summary>
        /// Nó destino
        /// </summary>
        public Node finOr = new Node();
        #endregion

        #region Construtor
        /// <summary>
        /// Construtor
        /// </summary>
        public Graph()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
            AddNode("Q0");
            this.qCount++;
        }

        #endregion

        #region Metodos

        #region Add Node
        /// <summary>
        /// Adiciona um no ao grafo
        /// </summary>
        /// <param name="name">Nome do no</param>
        public void AddNode(string name)
        {
            Node aux = new Node(name);

            if (Find(name) == null)
                nodes.Add(aux);
        }

        #endregion

        #region Add Edge
        /// <summary>
        /// Adiciona uma aresta entre dois nos
        /// </summary>
        /// <param name="nameFrom">Nome do no origem</param>
        /// <param name="nameTo">Nome do destino</param>
        /// <param name="cost">Nome do custo da aresta</param>
        public void AddEdge(string nameFrom, string nameTo, string cost)
        {
            Node from = Find(nameFrom);
            Node to = Find(nameTo);

            Edge e = new Edge(from, to, cost);

            from.AddEdge(to, cost);
            edges.Add(e);

        }

        #endregion

        #region Add Exp
        /// <summary>
        /// Adiciona a expressao no grafo com tipo or
        /// </summary>
        /// <param name="origem">Nome do no origem</param>
        /// <param name="destino">Nome origem</param>
        /// <param name="custo">no destino</param>
        /// <param name="isOr">é operador OR</param>
        public void AddExp(string origem, string destino, string custo, bool isOr)
        {
            if (isOrExpression)
            {
                isOrExpression = false;
                this.AddNode(origem);
                this.AddEdge(iniOr.Name, origem, "&");
                this.AddNode(destino);
                this.AddEdge(origem, destino, custo);
                this.AddEdge(destino, finOr.Name, "&");
            }
            else
            {
                Node node = this.nodes.Last();
                this.AddNode(origem);
                this.AddEdge(node.Name, origem, "&");
                this.AddNode(destino);
                this.AddEdge(origem, destino, custo);
                this.AddNode("Q" + this.qCount);
                this.AddEdge(destino, "Q" + this.qCount, "&");
                this.qCount++;
                if (isOr)
                {
                    iniOr = node;
                    finOr = this.nodes.Last();
                    isOrExpression = true;
                }
            }
        }

        /// <summary>
        /// Adiciona a expressao no grafo
        /// </summary>
        /// <param name="origem">Nome do no origem</param>
        /// <param name="destino">Nome origem</param>
        /// <param name="custo">no destino</param>
        public void AddExp(string origem, string destino, string custo)
        {
            if (isOrExpression)
            {
                isOrExpression = false;
                this.AddNode(origem);
                this.AddEdge(iniOr.Name, origem, "&");
                this.AddNode(destino);
                this.AddEdge(origem, destino, custo);
                this.AddEdge(destino, finOr.Name, "&");
            }
            else
            {
                Node node = this.nodes.Last();
                this.AddNode(origem);
                this.AddEdge(node.Name, origem, "&");
                this.AddNode(destino);
                this.AddEdge(origem, destino, custo);
                this.AddNode("Q" + this.qCount);
                this.AddEdge(destino, "Q" + this.qCount, "&");
                this.qCount++;
            }
        }
        #endregion

        #region Add Exp Mais
        /// <summary>
        /// Adiciona a expressao no grafo mais
        /// </summary>
        /// <param name="origem">Nome do no origem</param>
        /// <param name="destino">Nome origem</param>
        /// <param name="custo">no destino</param>
        public void AddExpMais(string origem, string destino, string custo)
        {
            Node node = this.nodes.Last();
            this.AddNode(origem);
            this.AddEdge(node.Name, origem, "&");
            this.AddNode(destino);
            this.AddEdge(origem, destino, custo);
            this.AddEdge(destino, origem, "&");
            this.AddNode("Q" + this.qCount);
            this.AddEdge(destino, "Q" + this.qCount, "&");
            this.qCount++;
        }
        #endregion

        #region Add Exp Cline
        public void AddExpCline(string origem, string destino, string custo)
        {
            Node node = this.nodes.Last();
            this.AddNode(origem);
            this.AddNode(destino);
            this.AddNode("Q" + this.qCount);
            this.AddEdge(node.Name, "Q" + this.qCount, "&");
            this.AddEdge(node.Name, origem, "&");
            this.AddEdge(origem, destino, custo);
            this.AddEdge(destino, origem, "&");
            this.AddEdge(destino, "Q" + this.qCount, "&");
            this.qCount++;
        }
        #endregion

        #endregion

        #region Define final Node
        /// <summary>
        /// Seta no como final do grafo
        /// </summary>
        public void DefineFinalNode()
        {
            var node = this.nodes.Find(u => u.Edges.Count == 0);
            if (node != null)
                node.isFinal = true;
            else
                this.nodes.Last().isFinal = true;
        }
        #endregion

        #region Find
        /// <summary>
        /// Procura o no do grafo
        /// </summary>
        /// <param name="info">Objeto</param>
        /// <returns>
        /// The method returns an integer.
        /// </returns>
        public Node Find(Object info)
        {
            foreach (Node node in nodes)
            {
                if (node.Name.Equals(info))
                    return node;
            }
            return null;
        }

        #endregion
    }
}