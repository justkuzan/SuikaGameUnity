using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private InputManager inputManager;
    
    private Flower _currentFlower;
    private float _lastSpawnTime;


    private void Start()
    {
        _lastSpawnTime = -settings.spawnCooldown;
        CreateFlowerInSpawner();
    }
    
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
        if (Time.time < _lastSpawnTime + settings.spawnCooldown) return;
        if (_currentFlower == null) return;
        _currentFlower.transform.SetParent(null);
        _currentFlower.SetPhysics(false);
        
        Vector2 dropVector = new Vector2(0, -1f);
        _currentFlower.flowerRB.AddForce(dropVector.normalized * settings.dropImpulse, ForceMode2D.Impulse);;
        
        _currentFlower = null;
        _lastSpawnTime = Time.time;
        
        Invoke(nameof(CreateFlowerInSpawner), settings.spawnCooldown);
    }

    public void CreateFlowerInSpawner()
    {
        FlowerData data = spawnManager.GetNextFlowerData();
        GameObject tempFlower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);
        _currentFlower = tempFlower.GetComponent<Flower>();
        _currentFlower.SetData(data);
        _currentFlower.SetPhysics(true);
       
        _currentFlower.transform.SetParent(this.transform);
    }
}