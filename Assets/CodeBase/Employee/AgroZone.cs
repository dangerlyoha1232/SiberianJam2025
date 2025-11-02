using CodeBase.Logic;
using System;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Employee
{
    public class AgroZone : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public LayerMask HeroLayer;
        public LayerMask ObstacleLayer;

        public event Action HeroNoticed;
        public GameObject Hero {get; private set;}

        private bool _heroOnAgroZone;
        private bool _heroAlreadyNoticed;

        private void Start()
        {
            TriggerObserver.OnTriggerEnter += HeroEntered;
            TriggerObserver.OnTriggerExit += HeroExited;
        }

        private void Update()
        {
            if (_heroOnAgroZone && !_heroAlreadyNoticed)
            {
                Vector3 direction = (Hero.transform.position - transform.position).normalized;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, HeroLayer | ObstacleLayer);

                if (hit.collider != null && hit.collider.gameObject == Hero)
                {
                    HeroNoticed?.Invoke();
                    _heroAlreadyNoticed = true;
                    Debug.Log("HeroNoticed");
                }
            }
        }

        private void HeroExited(Collider2D obj)
        {
            Hero = null;
            _heroOnAgroZone = false;
            Debug.Log("Hero Exited");
        }

        private void HeroEntered(Collider2D obj)
        {
            Hero = obj.gameObject;
            _heroOnAgroZone = true;
            Debug.Log("Hero entered" + obj.gameObject.name + obj.gameObject.layer);
        }
    }
}