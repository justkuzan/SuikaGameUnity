using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private InputManager inputManager;
    
    private void Update()
    {
        transform.position = new Vector3(inputManager.generatedX,transform.position.y,transform.position.z);
    }
    
    private void OnEnable()
    {
        GameEvents.OnInputClick += SpawnFlower;
    }
    
    private void OnDisable()
    {
        GameEvents.OnInputClick -= SpawnFlower;
    }
    
    public void SpawnFlower()
    {
        FlowerData data = spawnManager.GetRandomFlowerData();
        GameObject tempFlower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);
        Flower flowerScript = tempFlower.GetComponent<Flower>();
        flowerScript.SetData(data);
    }
}