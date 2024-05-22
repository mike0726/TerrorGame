using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform Player;
    public float velocidad;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

   
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        transform.position += direction * velocidad * Time.deltaTime;
    }
}
