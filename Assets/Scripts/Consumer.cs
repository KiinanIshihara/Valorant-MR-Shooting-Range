
using Unity.VisualScripting;
using UnityEngine;

public class Consumer : MonoBehaviour
{

    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider.GetComponent<Collider>();
        collider.isTrigger = true;
        
    }

    void OnTriggerEnter(Collider other) {
        Consumable consumable = other.GetComponent<Consumable>();
        if (consumable != null) {
            consumable.Consume();
        }
    }
}
