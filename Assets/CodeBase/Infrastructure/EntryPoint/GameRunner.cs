using UnityEngine;

namespace CodeBase.Infrastructure.EntryPoint
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameObject _gameBootstrapper;

        private void Awake()
        {
            GameBootstrapper gameBootstrapper = FindObjectOfType<GameBootstrapper>();
            
            if (gameBootstrapper != null)
                return;
            
            Instantiate(_gameBootstrapper);
        }
    }
}