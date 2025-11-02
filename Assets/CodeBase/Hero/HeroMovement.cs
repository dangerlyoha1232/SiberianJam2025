using CodeBase.CameraScripts;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private float _speed;
        
        private IInputService _inputService;

        public void Construct(float speed) =>
            _speed = speed;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            
            Camera.main.GetComponent<CameraFollow>().SetFollow(gameObject);
        }

        private void FixedUpdate()
        { 
            _rigidbody2D.MovePosition(_rigidbody2D.position + _inputService.Axis * _speed * Time.deltaTime);
        }
    }
}
