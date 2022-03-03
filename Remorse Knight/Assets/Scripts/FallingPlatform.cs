using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb =GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 2f);
        }
    }
    void DropPlatform()
    {
        Rb.isKinematic = false;
    }
}
