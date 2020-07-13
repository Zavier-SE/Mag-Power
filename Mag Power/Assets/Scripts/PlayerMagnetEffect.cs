using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetEffect : MonoBehaviour
{
    public Collider2D myCollider;
    public PointEffector2D mymagnetfield;

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        GameObject myObject = myCollider.gameObject;
        BasicPlayerControl otherPlayer = otherObject.GetComponent<BasicPlayerControl>();
        BasicPlayerControl myPlayer = myObject.GetComponent<BasicPlayerControl>();
        if (otherPlayer != null)
        {
            if (otherPlayer.playerMagnet == myPlayer.playerMagnet)
            {
                mymagnetfield.forceMagnitude = 17;
            }
            else
            {
                mymagnetfield.forceMagnitude = -17;
            }
        }
    }
}
