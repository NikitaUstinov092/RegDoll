
    public interface IGameListener
    {
    }
    public interface IGameStartListener : IGameListener
    {
        void OnStartGame();
    }
    
    public interface IGameFixedUpdateListener : IGameListener
    {
        void OnFixedUpdate(float deltaTime);
    }
