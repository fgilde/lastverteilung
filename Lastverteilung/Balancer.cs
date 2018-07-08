using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lastverteilung.Contracts;

namespace Lastverteilung
{
    public class Balancer
    {
        private readonly IList<IVirtualMachine> virtualMachines;

        public IList<IHypervisor> Hypervisors { get;}
  
        public IEnumerable<IVirtualMachine> NotAssignedVirtualMachines => virtualMachines.Where(vm => !Hypervisors.SelectMany(h => h.AssignedVirtualMachines).Contains(vm));

        public Balancer(IResourceLoader resourceLoader)
        {
            Hypervisors = new List<IHypervisor>(resourceLoader.LoadAvailableHypervisors());
            virtualMachines = new List<IVirtualMachine>(resourceLoader.LoadAvailableMachines());
            Balance();
        }

        private void Balance()
        {
            foreach (var vm in NotAssignedVirtualMachines)
            {
                Hypervisors.OrderBy(hv => hv.AssignedVirtualMachines.Count)
                    .ThenBy(hv => hv.FreeRam)
                    .FirstOrDefault(hv => hv.FreeRam >= vm.Ram)?.AssignedVirtualMachines.Add(vm);
            }
        }
    }
}