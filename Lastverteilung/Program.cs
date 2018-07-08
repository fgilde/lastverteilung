using System;
using System.Collections.Generic;
using Autofac;
using Lastverteilung.Contracts;
using Newtonsoft.Json;

namespace Lastverteilung
{
    class Program
    {
        static void Main(string[] args)
        {
            var balancer = IoC.Init().
                Resolve<Balancer>();
            Output(balancer.Hypervisors);
            Console.ReadLine();
        }

        private static void Output(IList<IHypervisor> balancerHypervisors)
        {
            string s = JsonConvert.SerializeObject(balancerHypervisors, Formatting.Indented);
            Console.WriteLine(s);
        }
    }
}
