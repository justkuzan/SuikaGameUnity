using UnityEngine;

public class MergeManager : MonoBehaviour
{
    [SerializeField] private GameObject flowerPrefab;
    
    
    private void OnEnable()
    {
        GameEvents.OnFlowersCollided += HandleMerge;
    }

    private void OnDisable()
    {
        GameEvents.OnFlowersCollided -= HandleMerge;
    }

    public void HandleMerge(FlowerData data, Vector3 flowerPosition)
    {
        if (data == null) Debug.Log("This was a last one");
        else
        {
            GameObject tempFlower = Instantiate(flowerPrefab, flowerPosition, Quaternion.identity);
            Flower flowerScript = tempFlower.GetComponent<Flower>();
            flowerScript.SetData(data);
        }
        
    }
}
