using GD.Events;
using GD.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProgressTracker : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The item data that is being tracked")]
    private ItemData itemData;

    [SerializeField]
    [Tooltip("The amount of the item required for the event to trigger")]
    private int desiredAmount;

    [SerializeField]
    [Tooltip("The event that is raised when this item goal is reached")]
    private GameEvent onGoalReached;

    [SerializeField]
    [Tooltip("Is the goal active")]
    private bool active;

    [SerializeField]
    [Tooltip("The inventroy being tracked")]
    private Inventory inventory;

    // Checks if the goal has been reached
    public void CheckProgress()
    {
        if (!active)
        {  return; }

        bool goalReached = inventory[itemData] >= desiredAmount;
        if (goalReached)
        {
            onGoalReached?.Raise();
        }
    }

}
