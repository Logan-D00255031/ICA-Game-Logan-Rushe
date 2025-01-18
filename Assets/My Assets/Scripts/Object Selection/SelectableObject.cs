using GD.Events;
using GD.Selection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : HighlightSelectionResponse
{
    [SerializeField]
    [Tooltip("The event that is called when the object is interacted with")]
    private GameEvent objectInteracted;
    [ReadOnly]
    [Tooltip("Determines if the object is currently interactable")]
    private bool interactable = false;

    // Update is called once per frame
    void Update()
    {
        if (!interactable)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            objectInteracted?.Raise();
        }
    }

    public override void OnSelect(Transform currentTransform)
    {
        interactable = true;
        base.OnSelect(currentTransform);
    }

    public override void OnDeselect(Transform currentTransform)
    {
        interactable = false;
        base.OnDeselect(currentTransform);
    }
}
