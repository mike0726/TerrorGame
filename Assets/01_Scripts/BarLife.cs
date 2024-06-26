using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class BarLife : MonoBehaviour
{
    public Image bar;
    public float life = 100;
    public float timeSpeed;
    [SerializeField]
     Light2D bateria;
    private float timer = 0.0f;
    public float interval = 0f;

    void Start()
    {
        bateria = GameObject.Find("BateriaLuz").GetComponent<Light2D>(); 
    }
    void Update()
    {
        
        timer += Time.deltaTime;

       
        if (timer >= interval)
        {
            ApagarBateria();
         
            timer = 0.0f;
        }
        //Debug.Log("Life: " + life);
        //Debug.Log("Bateria Intensity: " + bateria.intensity);

    }
    public void ApagarBateria()
    {
        life = Mathf.Clamp(life, 0, 100);

        bar.fillAmount = life / 100;

        if (life > 0)
        {
           life -= Time.deltaTime * timeSpeed;
            bateria.intensity = life * 0.01f;
        }
    }
}
