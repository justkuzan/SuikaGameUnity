using UnityEngine;

public class MergeManager : MonoBehaviour
{
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private ParticleSystem mergeParticlesPrefab;
    
    
    private void OnEnable()
    {
        GameEvents.OnFlowersCollided += HandleMerge;
    }

    private void OnDisable()
    {
        GameEvents.OnFlowersCollided -= HandleMerge;
    }

    public void HandleMerge(FlowerData currentData, FlowerData nextData, Vector3 flowerPosition)
    {
        ParticleSystem instance = Instantiate(mergeParticlesPrefab, flowerPosition, Quaternion.identity);
        ParticleSystemRenderer psRenderer = instance.GetComponent<ParticleSystemRenderer>();
        psRenderer.material.mainTexture = currentData.petalSprite;
        instance.Play();

        if (nextData != null)
        {
            GameObject tempFlower = Instantiate(flowerPrefab, flowerPosition, Quaternion.identity);
            tempFlower.GetComponent<Flower>().SetData(nextData);
        }
        else
        {
            Debug.Log("This was a last one");
        }
        
    }
}
