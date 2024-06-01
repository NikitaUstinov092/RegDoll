using UnityEngine;

    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _gameListenersObjects;
        private void Awake() 
        {
            var gameManager = GetComponent<GameManager>();

            foreach (var obj in _gameListenersObjects)
            {
                var listeners = obj.GetComponentsInChildren<IGameListener>();

                foreach (var listener in listeners)
                {
                    gameManager.AddListener(listener);
                }
            }
        }
    }
