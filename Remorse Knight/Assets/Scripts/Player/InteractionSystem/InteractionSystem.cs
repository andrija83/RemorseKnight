using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Player player { get; private set; }
    public Transform detectionPoint;
    public LayerMask detectionLayer;
    public float detectionRadius = 0.3f;
    public GameObject detectableItem;
    public PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectedObject())
        {
            if (InteractInput())
            {
                detectableItem.GetComponent<Item>().Interact();
                Debug.Log("INTERACT");
            }
        }

    }

    bool InteractInput()
    {
        return InputPLayer.GetInstance().GetInteractPressed();


    }
    bool DetectedObject()
    {
        Collider2D detected =  Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if(detected == null)
        {
            detectableItem = null;
            return false;
        }
        else
        {
            detectableItem = detected.gameObject;
            return true;
        }
    }
    
}
