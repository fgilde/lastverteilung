using System.Collections.Generic;

namespace Lastverteilung.Contracts
{
    public interface IResourceLoader
    {
        IEnumerable<IHypervisor> LoadAvailableHypervisors();
        IEnumerable<IVirtualMachine> LoadAvailableMachines();
    }
}