using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RayCastFlashLight : MonoBehaviour
{
    public bool pointing;
    private Camera mainCam;
    private Vector3 mousePos;
    RaycastHit2D rayhit;
    public GameObject point;
    public bool detectedEnemie;
    public float rayCastDistance;
    public LayerMask enemyLayerMask;
    float alpha = 1f;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RayCastDraw();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - transform.position;
        float angle= Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg;
       
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    public void RayCastDraw()
    {
        rayhit = Physics2D.Raycast(point.transform.position, point.transform.right, rayCastDistance, enemyLayerMask);

        if (rayhit.collider != null)
        {
            if (rayhit.collider.CompareTag("Enemy"))
            {
                
                detectedEnemie = true;
                alpha -= 0.001f;
                rayhit.collider.gameObject.GetComponent<Enemy1>().life -=1.8f;
                rayhit.collider.gameObject.GetComponent<Enemy1>().velocidad -= 0.1f;
                rayhit.collider.gameObject.GetComponent<Enemy1>().sprite.color = new Color(1,1,1,alpha);
                //Debug.Log("Enemy detected!");
                //Debug.DrawRay(point.transform.position, point.transform.right * rayCastDistance, Color.green);
            }
            else
            {
                detectedEnemie = false;
                //Debug.Log("Hit something else: " + rayhit.collider.tag);
                //Debug.DrawRay(point.transform.position, point.transform.right * rayCastDistance, Color.red);
            }
        }
        else
        {
            detectedEnemie = false;
            //Debug.Log("Nothing hit");
            //Debug.DrawRay(point.transform.position, point.transform.right * rayCastDistance, Color.red);
        }
    }
}
