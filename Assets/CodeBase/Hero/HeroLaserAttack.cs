using System;
using System.Collections;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroLaserAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _laserStartPoint;
        [SerializeField] private float _laserDistance = 3f;
        private IInputService _inputService;
        private Camera _camera;

        private float _manaCapacity;

        public float ManaCapacity {get; set;}
        public float ManaDrainPerSecond {get; set;}
        
        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _camera = Camera.main;
        }

        private void Start()
        {
            RestoreMana();
        }

        private void Update()
        {
            if (_inputService.IsAttackHold)
                CastLaser();
        }

        private void CastLaser()
        {
            Vector3 mousePositionInWorld = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            Vector3 laserDirection =  (mousePositionInWorld - transform.position).normalized;
            
            Physics2D.Raycast(_laserStartPoint.transform.position, laserDirection, _laserDistance);
            
            Debug.DrawRay(_laserStartPoint.transform.position, laserDirection * _laserDistance, Color.red);
        }
        
        public void RestoreMana() => _manaCapacity = ManaCapacity;
    }
}