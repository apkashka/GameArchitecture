namespace CodeBase.Data
{
    [System.Serializable]
    public class WorldData
    {
        public Vector3Data somePosition;
        public WorldData()
        {
            somePosition = new Vector3Data(0,0,0);
        }
    }

    [System.Serializable]
    public class Vector3Data
    {
        public Vector3Data(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X;
        public float Y;
        public float Z;
    }
}