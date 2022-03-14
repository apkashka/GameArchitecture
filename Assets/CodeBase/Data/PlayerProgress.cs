namespace CodeBase.Data
{
    [System.Serializable]
    public class PlayerProgress
    {
        public WorldData worldData;

        public PlayerProgress()
        {
            worldData = new WorldData();
        }
    }
}