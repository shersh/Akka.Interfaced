﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Akka.Interfaced;
using SlimUnity.Interface;

namespace SlimUnity.Program.Server
{
    public class CalculatorActor : InterfacedActor<CalculatorActor>, ICalculator
    {
        Task<string> ICalculator.Concat(string a, string b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");
            return Task.FromResult(a + b);
        }

        Task<int> ICalculator.Sum(int a, int b)
        {
            return Task.FromResult(a + b);
        }

        Task<int> ICalculator.Sum(Tuple<int, int> v)
        {
            return Task.FromResult(v.Item1 + v.Item2);
        }
    }
}