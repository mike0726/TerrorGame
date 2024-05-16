using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorItems : MonoBehaviour
{
    public bool TakeIt;
    public GameObject Item;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void InstanciarObjeto()
    {
        Instantiate(Item, new Vector2(transform.position.x, transform.position.y + 1.5f), transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Instantiate(Item, new Vector2(transform.position.x,transform.position.y +2),transform.rotation);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeIt = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeIt = false;
        }
    }
}
