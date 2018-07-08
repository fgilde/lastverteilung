using System.Collections.Generic;

namespace Lastverteilung.Contracts
{
    public interface IHypervisor
    {
        string Id { get; }
        double MaxRam { get; }
        double FreeRam { get; }
        IList<IVirtualMachine> AssignedVirtualMachines { get; }
    }
}