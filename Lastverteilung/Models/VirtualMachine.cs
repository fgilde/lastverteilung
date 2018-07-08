
using Lastverteilung.Contracts;
using Newtonsoft.Json;

namespace Lastverteilung.Models
{
    public class VirtualMachine : IVirtualMachine
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ram")]
        public double Ram { get; set; }
    }
}