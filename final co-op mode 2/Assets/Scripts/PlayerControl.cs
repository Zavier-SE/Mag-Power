using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public string moveRightKey;
    public string moveLeftKey;
    public string jumpKey;
    public string moveDownKey;
    //public string changeMagKey;
    public float speed;
    public float jumpStrength;
    public char playerStatus;
    public GameControl myGame;
    //public Vector2 RespawnPosition;


    public char playerMagnet = 'B';
    public float coolDownTime;

    private bool onGround = true;
    private float nextChangeTime;

	// Use this for initialization
	void Start () {
        playerStatus = 'L';
        //RespawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        move();
        //changeMagnet();
        //die();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        onGround = true;
    }

    void move (){
        //bool doJump = false;
        //if(Input.GetKey(moveRight)){
        //    playerRigidbody.velocity = Vector2.right * speed;
        //}else if(Input.GetKeyDown(moveRight) || Input.GetKeyDown(jump)){
        //    doJump = true;
        //}

        //if(Input.GetKey(moveLeft)){
        //    playerRigidbody.velocity = Vector2.left * speed;
        //}else if (Input.GetKeyDown(moveLeft) || Input.GetKeyDown(jump)) {
        //    doJump = true;
        //}

        //if(doJump){
        //    playerRigidbody.velocity = Vector2.up * jumpStrength;
        //    doJump = false;
        //}

        if (Input.GetKey(moveLeftKey)) 
        {
            //playerRigidbody.AddForce(Vector2.right * speed);
            playerRigidbody.velocity = new Vector2(-speed, playerRigidbody.velocity.y);
        } else if (Input.GetKey(moveRightKey)) 
        {
            //playerRigidbody.AddForce(Vector2.left * speed);
            playerRigidbody.velocity = new Vector2(speed, playerRigidbody.velocity.y);
        } else
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        if (Input.GetKeyDown(jumpKey) && onGround) {
            playerRigidbody.AddForce(Vector2.up * jumpStrength);
            onGround = false;
        }

    }

    /*void changeMagnet(){
        if (Input.GetKeyDown(changeMagKey)) {
            if (Time.time > nextChangeTime) {
                if (playerMagnet == 'B') {
                    playerMagnet = 'R';
                    GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                    nextChangeTime = Time.time + coolDownTime;
                }else if (playerMagnet == 'R') {
                    playerMagnet = 'B';
                    GetComponent<SpriteRenderer>().color = new Color(0, 170, 255);
                    nextChangeTime = Time.time + coolDownTime;
                }
            }
        }
    }*/

    /*void die(){
        if(playerStatus == 'D'){
           transform.position = RespawnPosition;
        }
    }*/

}
