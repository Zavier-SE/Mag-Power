using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObMagnetEffect : MonoBehaviour {

    public AreaEffector2D mymagnetfield;
    public char objectMagnet;

    private void OnTriggerStay2D(Collider2D other) {
        GameObject otherObject = other.gameObject;
        PlayerControl player = otherObject.GetComponent<PlayerControl>();
        if(player != null){
            if(player.playerMagnet == objectMagnet){
                mymagnetfield.forceMagnitude = 20;
            } else {
                mymagnetfield.forceMagnitude = -20;
            }
        }

    }

    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    //void Update () {

    //}
}
