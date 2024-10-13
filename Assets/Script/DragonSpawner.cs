using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public GameObject dragonPrefab; 
    public Transform spawnPoint; 

    private void Start()
    {
        // Check if the event is initialized before subscribing
        if (DragonSummonEvent.onDragonSummon != null)
        {
            DragonSummonEvent.onDragonSummon.AddListener(SpawnDragon);
        }
        else
        {
            Debug.LogError("DragonSummonEvent.onDragonSummon is not initialized.");
        }
    }

    private void SpawnDragon()
    {
        if (dragonPrefab != null && spawnPoint != null)
        {
            // Spawn the dragon at the defined spawn point
            Instantiate(dragonPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Dragon has been summoned.");
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        if (DragonSummonEvent.onDragonSummon != null)
        {
            DragonSummonEvent.onDragonSummon.RemoveListener(SpawnDragon);
        }
    }
}