using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteraccionObjeto : MonoBehaviour

{
    public string teclaInteraccion = "e";
    public GameObject objetoAInstanciar;
    public TextMeshProUGUI textoMesh;

    private bool estaEncimaDelObjeto = false;

    void Update()
    {
        if (estaEncimaDelObjeto && Input.GetKeyDown(teclaInteraccion))
        {
            MaterializarObjeto();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ObjetoInteractivo")) 
        {
            estaEncimaDelObjeto = true;
           // textoMesh.text = "Presiona '" + teclaInteraccion.ToUpper() + "' para interactuar";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ObjetoInteractivo"))
        {
            estaEncimaDelObjeto = false;
            //textoMesh.text = "";
        }
    }

    void MaterializarObjeto()
    {
        // Crea el objeto en las manos del personaje
        Instantiate(objetoAInstanciar, transform.position, Quaternion.identity);

        // Agrega lógica adicional según sea necesario.

        // También puedes destruir el objeto interactivo si ya no es necesario.
       // Destroy(GameObject.FindGameObjectWithTag("ObjetoInteractivo"));
    }
}

