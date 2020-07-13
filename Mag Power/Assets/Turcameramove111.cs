using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turcameramove111 : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraPosition = Vector3.zero;

    void Start()
    {
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPosition = new Vector3(
            Mathf.SmoothStep(transform.position.x,player.transform.position.x,0.3f),
             Mathf.SmoothStep(transform.position.y,transform.position.y,0.3f));
        
    }
        void LateUpdate()
    {
        transform.position = cameraPosition + Vector3.forward * -10; 
    }
}
