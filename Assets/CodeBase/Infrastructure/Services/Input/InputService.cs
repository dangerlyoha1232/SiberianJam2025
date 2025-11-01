using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 Axis => GetAxis();
        
        public bool IsAttackHold => UnityEngine.Input.GetMouseButton(0);

        private Vector2 GetAxis() =>
            new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
    }
}