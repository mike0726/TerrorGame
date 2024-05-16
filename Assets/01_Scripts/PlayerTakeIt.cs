using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerTakeIt : MonoBehaviour
{
    public bool ItemActivo;
    public bool ConItem;
    public GameObject PlayerItem;
    void Start()
    {
        
    }

   
    void Update()
    {

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.transform.parent = transform;
            ConItem = true;
            PlayerItem = collision.gameObject;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Instanciador"))
        {
            if (collision.gameObject.GetComponent<InstanciadorItems>().TakeIt)
            {
                ItemActivo = true;

            }
            if (Input.GetKeyDown(KeyCode.E) && ItemActivo && ConItem == false)
            {
              collision.gameObject.GetComponent<InstanciadorItems>().InstanciarObjeto();

            }
            if (Input.GetKeyDown(KeyCode.E) && ItemActivo && ConItem == true)
            {
                Destroy(PlayerItem);
                collision.gameObject.GetComponent<InstanciadorItems>().InstanciarObjeto();
            }
        }


    }
}
