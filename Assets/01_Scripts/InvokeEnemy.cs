using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

    public class InvokeEnemy : MonoBehaviour
    {
        public int CantidadEnemigos;
        public GameObject Enemigo;
        private GameObject enemigoInstanciado;
        private BarLife linterna;
        public bool activo = false;

        void Start()
        {
            linterna = GameObject.FindGameObjectWithTag("Player").GetComponent<BarLife>();
        }

        void Update()
        {
            // Comprueba si la linterna está vacía y el enemigo aún no ha sido invocado
            if (linterna.life <= 0 && !activo)
            {
                enemigoInstanciado = Instantiate(Enemigo, new Vector2(linterna.gameObject.transform.position.x + 5f, linterna.gameObject.transform.position.y), Quaternion.identity);
                activo = true;
            }

            // Comprueba si la linterna se ha recargado y el enemigo está activo
            if (linterna.life > 0 && activo)
            {
                // Destruye el enemigo instanciado y resetea el estado activo
                Destroy(enemigoInstanciado);
                activo = false;
            }
        }
    }
