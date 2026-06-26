using UnityEngine;
using _Project.Scripts.Utils;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private GameObject targetLine;
    
    private Flower _currentFlower;
    private float _lastSpawnTime;


    private void Start()
    {
        _lastSpawnTime = -settings.spawnCooldown;
        CreateFlowerInSpawner();
    }
    
    private void Update()
    {
        if (Services.Input != null)
        {
            transform.position = new Vector3(Services.Input.generatedX,transform.position.y,transform.position.z); 
        }
    }
    
    private void OnEnable()
    {
        GameEvents.OnInputClick += InputClick;
        GameEvents.OnInputPressed += InputPressed;
        GameEvents.OnGameOver += GameOver;
    }
    
    private void OnDisable()
    {
        GameEvents.OnInputClick -= InputClick;
        GameEvents.OnInputPressed -= InputPressed;
        GameEvents.OnGameOver -= GameOver;
    }

    public void InputClick()
    {
        SpawnFlower();
    }

    public void InputPressed()
    {
        ShowTargetLine();
    }

    private bool CanSpawn => Time.time >= _lastSpawnTime + settings.spawnCooldown && _currentFlower != null;
    public void SpawnFlower()
    {
        if (!CanSpawn) return;
        _currentFlower.transform.SetParent(null);
        _currentFlower.SetPhysics(false);
        
        Vector2 dropVector = new Vector2(0, -1f);
        _currentFlower.flowerRB.AddForce(dropVector.normalized * settings.dropImpulse, ForceMode2D.Impulse);;
        
        _currentFlower = null;
        _lastSpawnTime = Time.time;
        
        Invoke(nameof(CreateFlowerInSpawner), settings.spawnCooldown);
        
        targetLine.SetActive(false);
    }

    public void ShowTargetLine()
    {
        if (!CanSpawn) return;
        targetLine.SetActive(true);
    }
    
    public void CreateFlowerInSpawner()
    {
        FlowerData data = Services.Spawner.GetNextFlowerData();
        GameObject tempFlower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);
        _currentFlower = tempFlower.GetComponent<Flower>();
        _currentFlower.SetData(data);
        _currentFlower.SetPhysics(true);
       
        _currentFlower.transform.SetParent(transform);
    }

    public void GameOver()
    {
        enabled = false;
        GameEvents.OnGameOver -= GameOver;
    }
}