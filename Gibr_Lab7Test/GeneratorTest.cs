using Accord.Math.Optimization;
using Gibr_Lab7;
using Gibr_Lab7.Generator;
using Gibr_Lab7.Models;
using Gibr_Lab7.Solver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Gibr_Lab7Test
{
    class GeneratorTest
    {
        [Test]
        public void Test_1000_nodes()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            Generator flowGenerator = new Generator(9, 9, 9);
            int nodeCount = 1000;
            var (count, flows) = flowGenerator.generateNodes(nodeCount);
            stopwatch1.Stop();
            Console.WriteLine("Количество узлов " + nodeCount);
            Console.WriteLine("Количество потоков " + flows.Length);
            Console.WriteLine("Потрачено времени на генерацию: " + (stopwatch1.ElapsedMilliseconds));

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Calculator calculator = new Calculator();
            Result res = calculator.SolverNotArrays(count, flows);

            Console.WriteLine("Потрачено времени на рассчет: " + (stopwatch2.ElapsedMilliseconds));

            Assert.AreEqual(true, res.reduced);
        }

        [Test]
        public void Test_1500_nodes()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            Generator flowGenerator = new Generator(9, 9, 9);
            int nodeCount = 1500;
            var (count, flows) = flowGenerator.generateNodes(nodeCount);
            stopwatch1.Stop();
            Console.WriteLine("Количество узлов " + nodeCount);
            Console.WriteLine("Количество потоков " + flows.Length);
            Console.WriteLine("Потрачено времени на генерацию: " + (stopwatch1.ElapsedMilliseconds));

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Calculator calculator = new Calculator();
            Result res = calculator.SolverNotArrays(count, flows);

            Console.WriteLine("Потрачено времени на рассчет: " + (stopwatch2.ElapsedMilliseconds));

            Assert.AreEqual(true, res.reduced);
        }

        [Test]
        public void Test_2000_nodes()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            Generator flowGenerator = new Generator(9, 9, 9);
            int nodeCount = 2000;
            var (count, flows) = flowGenerator.generateNodes(nodeCount);
            stopwatch1.Stop();
            Console.WriteLine("Количество узлов " + nodeCount);
            Console.WriteLine("Количество потоков " + flows.Length);
            Console.WriteLine("Потрачено времени на генерацию: " + (stopwatch1.ElapsedMilliseconds));

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Calculator calculator = new Calculator();
            Result res = calculator.SolverNotArrays(count, flows);

            Console.WriteLine("Потрачено времени на рассчет: " + (stopwatch2.ElapsedMilliseconds));

            Assert.AreEqual(true, res.reduced);
        }
    }
}
