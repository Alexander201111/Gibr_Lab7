using Gibr_Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gibr_Lab7.Generator
{
    public class Generator
    {
        private Random random;
        private int sum;
        private int maxEdge;
        private int minEdge;

        public Generator()
        {
            this.random = new Random();
            this.sum = 15;
            this.maxEdge = 8;
            this.minEdge = 2;
        }

        public Generator(int sum, int maxEdge, int minEdge)
        {
            this.random = new Random();
            this.sum = sum;
            this.maxEdge = maxEdge;
            this.minEdge = minEdge;
        }

        public (int, Flow[]) generateNodes(int nodeCount)
        {
            Flow[][] nodes = new Flow[nodeCount][];
            int lastFlowId = 0;

            nodes[0] = generateFlows(-1, 1, 2, ref lastFlowId, nodes);

            for (int i = 1; i < nodeCount - 1; i++)
            {
                nodes[i] = generateFlows(i, i + 1, i + 2, ref lastFlowId, nodes);
            }

            nodes[nodeCount - 1] = generateFlows(nodeCount - 1, nodeCount, nodeCount + 1, ref lastFlowId, nodes);

            return (nodes.Length, nodes.SelectMany(x => x).ToArray());
        }

        public Flow[] generateFlows(int prevNodeId, int curNodeId, int nextNodeId, ref int lastFlowId, Flow[][] nodes)
        {
            List<Flow> flows = new List<Flow>();

            List<double> flowsWeightsIn = new List<double>();
            List<double> flowsWeightsOut = new List<double>();

            bool prevNodeIdUsed = false;
            bool nextNodeIdUsed = false;

            double bridgeFlowWeight = 0;

            if (prevNodeId != -1)
            {
                Flow[] preNode = nodes[prevNodeId - 1];
                Flow bridgeFlow = Array.Find(preNode, (flow) => flow.dest > 0 && flow.source > 0);
                prevNodeIdUsed = true;
                bridgeFlowWeight = bridgeFlow.D;
            }

            generateWeights(this.sum - bridgeFlowWeight, this.maxEdge, this.minEdge, flowsWeightsIn);
            generateWeights(this.sum, this.maxEdge, this.minEdge, flowsWeightsOut);

            double[] tolerance = new double[flowsWeightsIn.Count + flowsWeightsOut.Count];
            for (int j = 0; j < tolerance.Length; j++)
            {
                tolerance[j] = random.NextDouble();
            }

            int i = 0;
            foreach (double weight in flowsWeightsIn)
            {
                Flow flow = new Flow();

                if (!prevNodeIdUsed)
                {
                    flow.source = prevNodeId;
                    prevNodeIdUsed = true;
                }
                else
                {
                    flow.source = -1;
                }

                flow.dest = curNodeId;
                flow.w = tolerance[i];
                flow.D = weight;
                //flow.UpperBound = -1;
                //flow.LowerBound = -1;
                flow.Id = ++lastFlowId;

                flows.Add(flow);
                i++;
            }

            foreach (double weight in flowsWeightsOut)
            {
                Flow flow = new Flow();

                if (!nextNodeIdUsed)
                {
                    flow.dest = nextNodeId;
                    nextNodeIdUsed = true;
                }
                else
                {
                    flow.dest = -1;
                }

                flow.source = curNodeId;
                flow.w = tolerance[i];
                flow.D = weight;
                flow.Id = ++lastFlowId;

                flows.Add(flow);
                i++;
            }

            return flows.ToArray();
        }

        private void generateWeights(double number, int maxEdge, int minEdge, List<double> flowsWeights)
        {
            if (number <= minEdge)
            {
                flowsWeights.Add(number);
                return;
            }

            double rndNumber = random.NextDouble() * maxEdge;
            flowsWeights.Add(rndNumber);
            generateWeights(number - rndNumber, maxEdge, minEdge, flowsWeights);
        }
    }
}
