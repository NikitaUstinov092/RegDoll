using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace GameSystem.Scripts.GameSystem
{
    public enum GameState
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3
    }

    public class GameManager : MonoBehaviour
    {
       
        public GameState State
        {
            get { return state; }
        }
        
        [SerializeField]
        private GameState state;

        private List<IGameListener> _listeners = new();
        

        private List<IGameUpdateListener> _updateListeners = new();
        
        private List<IGameFixedUpdateListener> _fixedUpdateListeners = new();
        
        private List<IGameLateUpdateListener> _lateUpdateListeners = new();

        private void Start()
        {
            StartGame();
        }


        private void FixedUpdate()
        {
            if (state != GameState.PLAYING)
            {
                return;
            }
            
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

            if (listener is IGameUpdateListener updateListener)
            {
                _updateListeners.Add(updateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Add(fixedUpdateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Add(lateUpdateListener);
            }
        }


        public void RemoveListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }
            
            _listeners.Remove(listener);

            if (listener is IGameUpdateListener updateListener)
            {
                _updateListeners.Remove(updateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Remove(fixedUpdateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Remove(lateUpdateListener);
            }
        }
        
        public void StartGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameStartListener startListener)
                {
                    startListener.OnStartGame();
                }
            }

            state = GameState.PLAYING;
        }
        
        public void PauseGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }
            
            state = GameState.PAUSED;
        }
        
        public void ResumeGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }
            
            state = GameState.PLAYING;
        }
        
        public void FinishGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }
            
            state = GameState.FINISHED;
        }
    }
}