using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public FlowerCollection flowerCollection;
    public GameObject flowerPrefab;
    
    public float xClampValue = 3.6f;

    private void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = new Vector3(screenPos.x, screenPos.y, Mathf.Abs(mainCamera.transform.position.z));
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mouseWorldPosition);
        float xPosClamp = Mathf.Clamp(worldPos.x, -xClampValue, xClampValue);
        transform.position = new Vector3(xPosClamp,transform.position.y,transform.position.z);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            SpawnFlower();
        }
    }

    public void SpawnFlower()
    {
        FlowerData data = flowerCollection.flowers[Random.Range(0, flowerCollection.flowers.Count)];
        GameObject tempFlower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);
        Flower flowerScript = tempFlower.GetComponent<Flower>();
        flowerScript.SetData(data);
    }
}