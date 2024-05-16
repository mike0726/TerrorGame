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
    Light2D bateria;

    void Start()
    {
        bateria = GameObject.Find("Bateria").GetComponent<Light2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //limitar la cantidad que posee la barra de vida
        life = Mathf.Clamp(life, 0, 100);

        bar.fillAmount = life/100;

       if(life > 0)
        {
         life -= Time.deltaTime * timeSpeed; 
        bateria.intensity = life * 0.01f;
        } 
        
    }
}
