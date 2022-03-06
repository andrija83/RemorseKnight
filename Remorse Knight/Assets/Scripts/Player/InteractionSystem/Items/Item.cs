using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine }
    public InteractionType type;
    public InteractionSystem interactionSystem;
    public PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        interactionSystem = FindObjectOfType<InteractionSystem>();
        inventory = FindObjectOfType<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 9;
    }
    public void Interact()
    {
        switch (type)
        {            
            case InteractionType.PickUp:
                //interactionSystem.PickUpItem(this.gameObject);
                inventory.PickUpItem(gameObject);
                //FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                gameObject.SetActive(false);
                //Destroy(gameObject);
                Debug.Log("PICKUP");
                break;
            case InteractionType.Examine:
                //DIsplay Interact Dialog With INK
                Debug.Log("EXAMINE");
                break;
            default:
                Debug.Log("NULL");
                break;
        }
    }


}

