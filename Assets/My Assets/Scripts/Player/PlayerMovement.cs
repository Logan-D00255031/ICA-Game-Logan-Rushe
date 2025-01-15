using GD.Selection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask floorLayerMask;
    private NavMeshAgent playerAgent;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer();
        }
    }

    public bool MovePlayer()
    {
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
