using Projeto2_LFA.DATA_STRUCTURE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto2_LFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string eRegular="";
        Graph graph = new Graph();



        private void button1_Click(object sender, EventArgs e)
        {
            eRegular = expRegular.Text + "#";
            bool isOr = false;
            string aux = "";
            char op = ' ';
            foreach (char c in eRegular)
            {                

                if(c == '|') {
                    isOr = true;
                    graph.AddExp(aux + " inicial", aux + " final", aux, isOr);
                    aux = "";
                }
                else if (c == '.')
                {
                    graph.AddExp(aux + " inicial", aux + " final", aux, isOr);
                    isOr = false;
                    aux = "";
                }
                else if (c == '#')
                {
                    graph.AddExp(aux + " inicial", aux + " final", aux, isOr);
                    isOr = false;
                    aux = "";
                }
                else
                {
                    aux += c;
                }
                
            }
            this.graph.defineFinalNode();
        }
    }
}
