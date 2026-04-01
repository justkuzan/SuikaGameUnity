using UnityEngine;

public class Spawner : MonoBehaviour
{
    public FlowerCollection flowerCollection;

    private Vector3 mousePosition;
    
    void Update()
    { 
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private void Instantiate()
    {
        var flower = flowerCollection[Random.Range(0, flowerCollection.Count)];
        
       if (Input.GetMouseButtonDown(0))
       {
           Instantiate(flower, transform.position, transform.rotation);
       }
    }
}
