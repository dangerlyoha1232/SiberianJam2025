using System;

namespace CodeBase.Logic
{
    public interface IManaHolder
    {
        float ManaCapacity { get; }
        event Action OnManaCapacityChanged;
    }
}