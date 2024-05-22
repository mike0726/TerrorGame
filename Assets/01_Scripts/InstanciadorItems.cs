using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//public class InstanciadorItems : MonoBehaviour
//{
//  public bool TakeIt;
//    public GameObject Item;
//    private GameObject currentItem;
//    private bool itemRecogido = false;
//    void Start()
//    {

//    }


//    void Update()
//    {

//    }
//    public void InstanciarObjeto()
//    {
//       // Instantiate(Item, new Vector2(transform.position.x, transform.position.y + 1.5f), transform.rotation);
//        if (!itemRecogido)
//        {
//            // Si el ítem no ha sido recogido, instanciar uno nuevo
//            //currentItem = Instantiate(Item, transform.position, transform.rotation);
//            currentItem = Instantiate(Item, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
//            itemRecogido = true;
//        }
//        else
//        {
//            // Si el ítem ya ha sido recogido, destruir el ítem existente y crear uno nuevo
//            Destroy(currentItem);
//            //currentItem = Instantiate(Item, transform.position, transform.rotation);
//            currentItem = Instantiate(Item, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
//        }
//    }


//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.gameObject.CompareTag("Player"))
//        {
//        if (!itemRecogido)
//        {
//            InstanciarObjeto();
//        } //Instantiate(Item, new Vector2(transform.position.x,transform.position.y +2),transform.rotation);
//    }

//    }
//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {

//         TakeIt = true;
//        }
//    }
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//           TakeIt = false;
//        }
//    }
//}

public class InstanciadorItems : MonoBehaviour
{
    public bool TakeIt;
    public GameObject itemPrefab;
    private GameObject currentItem;
    private bool playerInZone = false;
    private GameObject player;

    void Start()
    {

    }

    void Update()
    {
        // Verificar si el jugador está en la zona y presiona la tecla "E"
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            InstanciarObjeto();
        }
    }

    public void InstanciarObjeto()
    {
        // Verificar si el jugador ya tiene un ítem
        PlayerTakeIt playerTakeIt = player.GetComponent<PlayerTakeIt>();
        if (playerTakeIt.ConItem)
        {
            // Si el jugador ya tiene un ítem, destruir el ítem existente y crear uno nuevo
            Destroy(playerTakeIt.PlayerItem);
        }

        // Instanciar el nuevo ítem
        currentItem = Instantiate(itemPrefab, new Vector2(transform.position.x, transform.position.y + 1.5f), transform.rotation);
        playerTakeIt.PlayerItem = currentItem;
        playerTakeIt.ConItem = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInZone = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInZone = false;
            player = null;
        }
    }
}

