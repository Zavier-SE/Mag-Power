using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceEndOb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject playerObject = collision.gameObject;
        CircleCollider2D[] coliders = playerObject.GetComponents<CircleCollider2D>();
        if (collision == coliders[0])
        {
            BasicPlayerControl player = playerObject.GetComponent<BasicPlayerControl>();
            player.playerStatus = 'W';
        }
    }
}
