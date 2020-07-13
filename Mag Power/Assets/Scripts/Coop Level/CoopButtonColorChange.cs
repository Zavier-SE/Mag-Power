using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopButtonColorChange : MonoBehaviour{

	private void OnTriggerEnter2D(Collider2D collision)
    	{
        	GameObject playerObject = collision.gameObject;
	        CircleCollider2D[] coliders = playerObject.GetComponents<CircleCollider2D>();
    	    if (collision == coliders[0])
        	{
            	GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        	}
    	}

}