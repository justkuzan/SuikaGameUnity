using UnityEngine;
using UnityEngine.InputSystem;

public class DebugManager : MonoBehaviour
{
    public GameObject debugPanel;
    public Spawner spawner;
    
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
            spawner.SpawnFlower();
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
