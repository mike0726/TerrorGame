using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform Player;
    public float velocidad;
    AudioSource audioSource;
    public AudioClip clip;
    public float minDistance;
    public Vector2 playerDistance;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

   
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        transform.position += direction * velocidad * Time.deltaTime;
        playerDistance = Vector2.MoveTowards(transform.position, Player.transform.position,minDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
