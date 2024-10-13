using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public GameObject dragonPrefab; // Reference to the dragon prefab
    public Transform spawnPoint; // Where the dragon will appear

    private void Start()
    {
        // Subscribe to the event
        DragonSummonEvent.onDragonSummon.AddListener(SpawnDragon);
    }

    private void SpawnDragon()
    {
        // Spawn the dragon at the defined spawn point
        Instantiate(dragonPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Dragon has been summoned.");
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        DragonSummonEvent.onDragonSummon.RemoveListener(SpawnDragon);
    }
}