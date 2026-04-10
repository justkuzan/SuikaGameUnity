using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MergeManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private ParticleSystem mergeParticlesPrefab;

    public void Start()
    {
        Prewarm();
    }

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
            Flower flowerScript = tempFlower.GetComponent<Flower>();
            flowerScript.SetData(nextData);
            
            flowerScript.flowerRB.AddForce(Vector2.up * settings.mergeJumpForce, ForceMode2D.Impulse);
            
            float direction = Random.value > 0.5f ? 1f : -1f; 
            float torque = direction * settings.mergeRotationForce;
            flowerScript.flowerRB.AddTorque(torque, ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("This was a last one");
        }
        
    }

    private void Prewarm()
    {
        Vector3 tempPosition = new Vector3(100, 100, 0);
        GameObject tempFlower = Instantiate(flowerPrefab,tempPosition, Quaternion.identity);
        Destroy(tempFlower);
        
        ParticleSystem tempParticles = Instantiate(mergeParticlesPrefab, tempPosition, Quaternion.identity);
    }
}
