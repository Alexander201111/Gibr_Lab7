using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gibr_Lab7.Models;

namespace Generator
{
    class Generator
    {
        private Random random;
        private int m_sum;
        private int m_maxEdge;
        private int m_minEdge;

        public Generator()
        {
            this.random = new Random();
            this.m_sum = 15;
            this.m_maxEdge = 8;
            this.m_minEdge = 2;
        }

        public Generator(int m_sum, int m_maxEdge, int m_minEdge)
        {
            this.random = new Random();
            this.m_sum = m_sum;
            this.m_maxEdge = m_maxEdge;
            this.m_minEdge = m_minEdge;
        }

        public Flow[] generateNodes(int nodeCount)
        {
            Flow[][] nodes = new Flow[nodeCount][];
            int lastFlowId = 0;

            nodes[0] = generateFlowsOfNode(-1, 1, 2, ref lastFlowId, nodes);

            for (int i = 1; i < nodeCount - 1; i++)
            {
                nodes[i] = generateFlowsOfNode(i, i + 1, i + 2, ref lastFlowId, nodes);
            }

            nodes[nodeCount - 1] = generateFlowsOfNode(nodeCount - 1, nodeCount, nodeCount + 1, ref lastFlowId, nodes);

            return nodes.SelectMany(x => x).ToArray();
        }
    }
}
