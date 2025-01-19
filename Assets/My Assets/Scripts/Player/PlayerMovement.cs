using GD.Selection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask floorLayerMask;
    private NavMeshAgent playerAgent;

    private SphereOverlapSelector sOverlapSelector;
    private GameObjectRayProvider rayProvider;

    private Transform previousSelection;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        sOverlapSelector = GetComponent<SphereOverlapSelector>();
        rayProvider = GetComponent<GameObjectRayProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer();
        }

        CheckForSelectables();

    }

    private void CheckForSelectables()
    {
        sOverlapSelector.CheckAt(transform.position);
        Transform currentSelection = sOverlapSelector.GetSelection();
        if (currentSelection != null)
        {
            // Check if the selection is a new one
            if (currentSelection != previousSelection)
            {
                Debug.Log("New Selection found!");
                // Deselect the previous selection if it exists
                if (previousSelection != null)
                {
                    Deselect(previousSelection);
                }

                Select(currentSelection);

                previousSelection = currentSelection;
            }
        }
        else if (previousSelection != null)
        {
            Deselect(previousSelection);
            previousSelection = null;
        }
    }

    private static void Select(Transform selected)
    {
        var newSelectionResponse = selected.GetComponent<SelectionResponse>();
        newSelectionResponse.OnSelect(selected);
        Debug.Log($"Selected {selected.name}");
    }

    private void Deselect(Transform transform)
    {
        var lastSelectionResponse = transform.GetComponent<SelectionResponse>();
        lastSelectionResponse.OnDeselect(transform);
        Debug.Log($"Deselected {transform.name}");
    }

    public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();

    public bool MovePlayer()
    {
        // The player shouldn't move if the mouse is clicked over a UI element
        if(IsPointerOverUI())
        {
            return false;
        }

        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);    // Create a ray at camera mouse position
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 100, floorLayerMask)) // Check if the raycast hit the floor
        {
            Vector3 selectedPosition = raycastHit.point;

            playerAgent.SetDestination(selectedPosition); // Move player to the position

            return true;
        }
        return false;
    }
}
