using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObstacle : MonoBehaviour {

    public float x;
    public float y;

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject playerObject = collision.gameObject;
        CircleCollider2D[] coliders = playerObject.GetComponents<CircleCollider2D>();
        if (collision == coliders[0]){

            playerObject.transform.position = new Vector2(x,y);
        }
    }
}
