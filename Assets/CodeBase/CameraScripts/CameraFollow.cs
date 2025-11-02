using UnityEngine;

namespace CodeBase.CameraScripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);
        private GameObject _follow;

        public void SetFollow(GameObject follow) =>
            _follow = follow;

        private void LateUpdate() =>
            transform.position = _follow.transform.position +  _offset;
    }
}
