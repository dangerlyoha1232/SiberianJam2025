using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 Axis => GetAxis();
        
        public bool IsAttackHold => UnityEngine.Input.GetMouseButton(0);

        public bool IsAttackDown => UnityEngine.Input.GetMouseButtonDown(0);
        public bool IsAttackUp => UnityEngine.Input.GetMouseButtonUp(0);

        private Vector2 GetAxis() =>
            new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
    }
}