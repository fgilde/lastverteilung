using System;
using System.Collections.Generic;
using System.IO;
using Lastverteilung.Contracts;
using Lastverteilung.Models;
using Newtonsoft.Json.Linq;

namespace Lastverteilung
{
    public class JsonResourceLoader : IResourceLoader
    {
        private readonly string resourceDirectory = Path.Combine(Environment.CurrentDirectory, "Resources");

        public IEnumerable<IHypervisor> LoadAvailableHypervisors()
        {
            string filename = Path.Combine(resourceDirectory, "hypervisor.json");
            return JObject.Parse(File.ReadAllText(filename)).SelectToken("hypervisors").ToObject<IEnumerable<Hypervisor>>();
        }

        public IEnumerable<IVirtualMachine> LoadAvailableMachines()
        {
            string filename = Path.Combine(resourceDirectory, "vms.json");
            return JObject.Parse(File.ReadAllText(filename)).SelectToken("vms").ToObject<IEnumerable<VirtualMachine>>();
        }
    }
}