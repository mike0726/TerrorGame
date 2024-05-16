using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight2D : MonoBehaviour
{
    public bool pointing;
    private Camera mainCam;
    private Vector3 mousePos;
    
    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

      

        //radianes
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        //grados
        float angle2 = (180 / Mathf.PI) * angle - 90;

        transform.rotation = Quaternion.Euler(0, 0, angle2);
    }
}
