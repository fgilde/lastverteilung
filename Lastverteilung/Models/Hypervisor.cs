using System.Collections.Generic;
using System.Linq;
using Lastverteilung.Contracts;
using Newtonsoft.Json;

namespace Lastverteilung.Models
{
    public class Hypervisor : IHypervisor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("maxram")]
        public double MaxRam { get; set; }

        [JsonIgnore]
        public double FreeRam => MaxRam - AssignedVirtualMachines.Sum(vm => vm.Ram);

        [JsonProperty("vms")]
        public IList<IVirtualMachine> AssignedVirtualMachines { get; } = new List<IVirtualMachine>();

    }
}