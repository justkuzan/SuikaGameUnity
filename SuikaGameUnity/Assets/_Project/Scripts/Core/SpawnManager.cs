using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public FlowerCollection flowerCollection;

    public FlowerData GetRandomFlowerData()
    {
        FlowerData data = flowerCollection.flowers[Random.Range(0, flowerCollection.flowers.Count)];
            return data;
    }
}
