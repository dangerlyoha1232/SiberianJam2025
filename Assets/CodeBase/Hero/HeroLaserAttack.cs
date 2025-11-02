using System;
using System.Collections;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(LineRenderer))]
    public class HeroLaserAttack : MonoBehaviour, IManaHolder
    {
        [SerializeField] private GameObject _laserStartPoint;
        [SerializeField] private float _laserDistance = 3f;
        [SerializeField] private LayerMask _employeeMask;
        [SerializeField] private float _manaDrainCooldown = 1f; 
        private float _actualCooldown;

        private IInputService _inputService;
        private Camera _camera;
        private LineRenderer _lineRenderer;

        private float _currentMana;
        private float _maxMana;

        public float ManaCapacity
        {
            get => _currentMana;
            set
            {
                _currentMana = Mathf.Clamp(value, 0, _maxMana);
                OnManaCapacityChanged?.Invoke();
            }
        }

        private float ManaDrainPerSecond { get; set; }

        public event Action OnManaCapacityChanged;

        public void Construct(float manaCapacity, float manaDrainPerSecond)
        {
            _maxMana = manaCapacity;
            _currentMana = manaCapacity;
            ManaDrainPerSecond = manaDrainPerSecond;
        }

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _camera = Camera.main;
            _lineRenderer = GetComponent<LineRenderer>();
            
            _lineRenderer.positionCount = 2;
            _lineRenderer.enabled = false;
            _lineRenderer.startWidth = 0.05f;
            _lineRenderer.endWidth = 0.05f;
            _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            _lineRenderer.startColor = Color.red;
            _lineRenderer.endColor = Color.red;
        }

        private void Update()
        {
            if (_inputService.IsAttackHold && _currentMana > 0)
            {
                CastLaser();
            }
            else
            {
                _lineRenderer.enabled = false;
            }
        }

        private void CastLaser()
        {
            Vector3 mousePositionInWorld = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 laserDirection = (mousePositionInWorld - transform.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(_laserStartPoint.transform.position, laserDirection, _laserDistance,
                _employeeMask);
            
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _laserStartPoint.transform.position);

            Vector3 endPoint;

            if (hit.collider != null)
            {
                endPoint = hit.point;

                if (hit.collider.TryGetComponent(out ITakeMana manaReceiver))
                {
                    manaReceiver.TakeMana(ManaDrainPerSecond * Time.deltaTime);
                }
            }
            else
            {
                endPoint = _laserStartPoint.transform.position + laserDirection * _laserDistance;
            }

            _lineRenderer.SetPosition(1, endPoint);
            
            SpendMana(Time.deltaTime);
        }

        private void SpendMana(float deltaTime)
        {
            _currentMana -= ManaDrainPerSecond * deltaTime;
            _currentMana = Mathf.Max(0, _currentMana);
            OnManaCapacityChanged?.Invoke();
        }

        public void RestoreMana()
        {
            _currentMana = _maxMana;
            OnManaCapacityChanged?.Invoke();
        }
    }
}