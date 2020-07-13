using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetEffect : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
    public Collider2D myCollider;
    public PointEffector2D mymagnetfield;

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        GameObject myObject = myCollider.gameObject;
        PlayerControl otherPlayer = otherObject.GetComponent<PlayerControl>();
        PlayerControl myPlayer = myObject.GetComponent<PlayerControl>();
        if (otherPlayer != null)
        {
            if (otherPlayer.playerMagnet == myPlayer.playerMagnet)
            {
                mymagnetfield.forceMagnitude = 100;
            }
            else
            {
                mymagnetfield.forceMagnitude = -100;
            }
        }
    }
}
