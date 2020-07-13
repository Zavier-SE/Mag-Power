using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitbutton : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Application.Quit();
        }
    }
}
