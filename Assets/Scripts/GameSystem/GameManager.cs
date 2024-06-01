using System.Collections.Generic;
using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        
        private List<IGameListener> _listeners = new();

        private List<IGameFixedUpdateListener> _fixedUpdateListeners = new();
        
        private void Start()
        {
            StartGame();
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            for (int i = 0, count = _fixedUpdateListeners.Count; i < count; i++)
            {
                var listener = _fixedUpdateListeners[i];
                listener.OnFixedUpdate(deltaTime);
            }
        }
        
        public void AddListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }
            
            _listeners.Add(listener);
            

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Add(fixedUpdateListener);
            }
        }


        public void RemoveListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }
            
            _listeners.Remove(listener);
            

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Remove(fixedUpdateListener);
            }
            
        }
        
        private void StartGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameStartListener startListener)
                {
                    startListener.OnStartGame();
                }
            }
        }

}
