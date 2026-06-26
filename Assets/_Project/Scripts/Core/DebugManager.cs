using UnityEngine;
using UnityEngine.InputSystem;
using _Project.Scripts.Utils;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private GameObject debugPanel;
    
    private void Awake()
    {
        Services.Debugger = this;
    }
    
    #if UNITY_EDITOR
    public void Update()
    {
        if (Keyboard.current.backquoteKey.wasPressedThisFrame)
        {
            debugPanel.SetActive(!debugPanel.activeSelf);
        }
    }
    #endif

    public void SpawnFlowers10()
    {
        int flowersToSpawn = 10;

        for (int i = 0; i < flowersToSpawn-1; i++)
        {
            float randomX = Random.Range(-settings.movementLimitX, settings.movementLimitX);
            Vector3 randomPosition = new Vector3(randomX, 5, 0);
            
            int randomIndex = Random.Range(0, Services.Spawner.flowerCollection.flowers.Count);
            FlowerData data = Services.Spawner.flowerCollection.flowers[randomIndex];
            
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
