using UnityEngine;
using UnityEngine.InputSystem;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject debugPanel;
    
    
    public void Update()
    {
        if (Keyboard.current.backquoteKey.wasPressedThisFrame)
        {
            debugPanel.SetActive(!debugPanel.activeSelf);
        }
    }

    public void SpawnFlowers10()
    {
        int flowersToSpawn = 10;

        for (int i = 0; i < flowersToSpawn-1; i++)
        {
            float randomX = Random.Range(-settings.movementLimitX, settings.movementLimitX);
            Vector3 randomPosition = new Vector3(randomX, 5, 0);
            
            int randomIndex = Random.Range(0, spawnManager.flowerCollection.flowers.Count);
            FlowerData data = spawnManager.flowerCollection.flowers[randomIndex];
            
            GameObject newObject = Instantiate(flowerPrefab, randomPosition, Quaternion.identity);
            
            Flower flowerScript = newObject.GetComponent<Flower>();
            flowerScript.SetData(data);
            flowerScript.SetPhysics(false);
        }
    }
    
    public void DeleteFlowers()
    {
        GameObject[] flowers = GameObject.FindGameObjectsWithTag("Flower");
        foreach (GameObject flower in flowers)
        {
            Destroy(flower);
        }
    }
}
