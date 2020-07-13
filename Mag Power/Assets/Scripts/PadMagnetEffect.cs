using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMagnetEffect : MonoBehaviour
{
    public AreaEffector2D mymagnetfield;
    public char objectMagnet;

    private void OnTriggerStay2D(Collider2D other) {
        GameObject otherObject = other.gameObject;
        BasicPlayerControl player = otherObject.GetComponent<BasicPlayerControl>();
        if(player != null){
            if(player.playerMagnet == objectMagnet){
                mymagnetfield.forceMagnitude = 20;
            } else {
                mymagnetfield.forceMagnitude = -20;
            }
        }
    }

}
