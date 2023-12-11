using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPlacementManager : MonoBehaviour
{
    public GameObject objectToPlacePrefab;

    void Start()
    {
        // Automatically place the object on the floor
        PlaceObjectOnFloor();
    }

    void PlaceObjectOnFloor()
    {
        // Raycast to find the floor
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f, LayerMask.GetMask("Floor")))
        {
            // Check if there are no obstacles within a 1-meter radius
            if (!ObstaclesInRadius(hit.point, 0.5f))
            {
                // Place the object at the hit point
                PlaceObject(hit.point, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Obstacles detected within the placement radius. Adjust placement logic.");
            }
        }
        else
        {
            Debug.LogWarning("No floor detected. Adjust placement logic.");
        }
    }

    bool ObstaclesInRadius(Vector3 center, float radius)
    {
        // Check for obstacles within the specified radius
        Collider[] colliders = Physics.OverlapSphere(center, radius);
        return colliders.Length > 0;
    }

    void PlaceObject(Vector3 position, Quaternion rotation)
    {
        // Instantiate the object
        GameObject placedObject = Instantiate(objectToPlacePrefab, position, rotation);

        // Additional logic can be added based on your specific requirements
    }
}
