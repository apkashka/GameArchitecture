using UnityEngine.AddressableAssets;

namespace CodeBase.Data.StaticData
{
    public class UnitData
    {
        public int ID;
        public string Resou;
        public int Health;
        public int Damage;

        public AssetReferenceGameObject some;

        public override string ToString()
        {
            return $"Unit with {ID} id has {Health} health and {Damage} damage";
        }
    }
}