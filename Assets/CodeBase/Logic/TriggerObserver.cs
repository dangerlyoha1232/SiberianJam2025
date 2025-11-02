using System;
using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;
        
        private void OnTriggerEnter2D(Collider2D other) =>
            OnTriggerEnter?.Invoke(other);
        
        private void OnTriggerExit2D(Collider2D other) =>
        OnTriggerExit?.Invoke(other);
    }
}