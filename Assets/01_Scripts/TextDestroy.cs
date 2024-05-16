using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextDestroy : MonoBehaviour
{
    public float TimeDestroy;
    void Start()
    {
        Destroy(this.gameObject, TimeDestroy);
    }

    void Update()
    {
        
    }
}
