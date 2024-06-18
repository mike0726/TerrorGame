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
    public float playerDistance;
    public SpriteRenderer sprite;
    public float life=100f;
    public Player player;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

   
    void Update()
    {
        velocidad = Mathf.Clamp(velocidad, 0.8f, 5.0f);
        playerDistance = Vector2.Distance(transform.position, Player.transform.position);
        if (playerDistance >= 0)
        {
            SawPlayer();
            audioSource.volume += 0.001f;
        }
        
        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        transform.position += direction * velocidad * Time.deltaTime;

       

        if (life <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void SawPlayer()
    {
        if (Player.transform.position.x > transform.position.x)
        {
            sprite.flipX = false;
        }
        if (Player.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.TakeDamage();
            //Destroy(this.gameObject);
        }
    }
}
