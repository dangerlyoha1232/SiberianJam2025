using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public float Speed { get; set; }
        
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void FixedUpdate()
        { 
            _rigidbody2D.MovePosition(_rigidbody2D.position + _inputService.Axis * Speed * Time.deltaTime);
        }
    }
}
