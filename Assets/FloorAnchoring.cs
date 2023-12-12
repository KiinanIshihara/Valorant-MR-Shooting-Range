using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAnchoring : MonoBehaviour
{
   void Start()
    {
        // Make sure the GameObject has a collider attached
        Collider collider = GetComponent<Collider>();

        if (collider != null)
        {
            // Get the floor height from the Oculus boundary system
            float floorHeight = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.PlayArea)[0].y;

            // Adjust the position of the GameObject to the floor height
            Vector3 newPosition = new Vector3(transform.position.x, floorHeight + collider.bounds.extents.y, transform.position.z);
            transform.position = newPosition;
        }
        else
        {
            Debug.LogError("Collider component not found on the GameObject.");
        }
    }
}