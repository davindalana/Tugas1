using UnityEngine;
using UnityEngine.Events;

public class DragonSummonEvent : MonoBehaviour
{
    public static UnityEvent onDragonSummon; // Define static event for dragon summon

    private void Start()
    {
        if (onDragonSummon == null)
        {
            onDragonSummon = new UnityEvent();
        }
    }

    public static void TriggerDragonSummon()
    {
        if (onDragonSummon != null)
        {
            onDragonSummon.Invoke(); // Invoke the event to summon the dragon
            Debug.Log("Dragon summon event triggered.");
        }
    }
}