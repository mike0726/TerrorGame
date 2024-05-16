using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destinationPortal; // Asigna el portal de destino en el Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TeleportPlayer(collision.gameObject));
        }
    }



    IEnumerator TeleportPlayer(GameObject player)
    {
        yield return new WaitForSeconds(0.1f);


        player.transform.position = new Vector2(destinationPortal.transform.position.x, destinationPortal.transform.position.y);

    }
}


