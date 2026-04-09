using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    
    public FlowerCollection flowerCollection;

    private int _totalSpawns;
    private float _totalRate;
    
    public FlowerData GetNextFlowerData()
    {
        _totalSpawns++;
        if (_totalSpawns <= settings.lvl1DropQuantity) return flowerCollection.flowers[0];
        if (_totalSpawns <= settings.lvl2DropQuantity) return flowerCollection.flowers[Random.Range(0,2)];
        if (_totalSpawns <= settings.lvl3DropQuantity) return flowerCollection.flowers[Random.Range(0,3)];
        
        return GetWeightedRandomFlower();
    }

    public FlowerData GetWeightedRandomFlower()
    {
        _totalRate = 0;
        foreach (FlowerData flower in flowerCollection.flowers)
        {
            _totalRate += flower.dropRate;
        }
        
        var roll = Random.Range(0, _totalRate);

        foreach (FlowerData flower in flowerCollection.flowers)
        {
            roll -= flower.dropRate;
            if (roll <= 0) return flower;
        }
        
        return flowerCollection.flowers[0];
    }
}
