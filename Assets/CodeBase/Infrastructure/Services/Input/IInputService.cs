using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        bool IsAttackHold { get; }
        
        bool IsAttackDown { get; }
        bool IsAttackUp { get; }
    }
}