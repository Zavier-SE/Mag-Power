using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicPlayerControl : MonoBehaviour
{
	public Rigidbody2D playerRigidbody;

    //Level Control
    public string LevelName;


	//Control Keys
	public string moveRightKey;
    public string moveLeftKey;
    public string jumpKey;
    public string changeMagKey;

    //attributes
    public char playerMagnet = 'R';
    public float speed;
    public float jumpStrength;
    public char playerStatus;
 	public float MagChangeCoolDownTime;

    public GameControl myGame;

    private bool onGround = true;
    private float nextMagChangeTime;
    public Vector2 RespawnPosition;
    public Singlerespawnpoint respawn;

    //battle lv
    public string specialMagKey;
    public float abilityStrenth;
    public BattleHealthBar playerHealthBar;

    public float AbilityCoolDownTime;
    public float AbilityDuration;

    private float nextSpecialAbilityTime;
    private float playerHealth = 1;


    // Start is called before the first frame update
    void Start()
    {
        playerStatus = 'L';
        RespawnPosition = transform.position;
        Singlerespawnpoint thePlayer = FindObjectOfType<Singlerespawnpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(LevelName == "BATTLE"){
            changeMagnet();
            specialAbility();
            if (playerHealth <= 0.01)
            {
                playerStatus = 'D';
            }
            die();
        } else if(LevelName == "RACE"){
            changeMagnet();
            die();
        }else if(LevelName == "ADVENTURE"){
            changeMagnet();
        }
    }

    void move()
    {
        if (Input.GetKey(moveRightKey))
        {
            playerRigidbody.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(moveLeftKey))
        {
            playerRigidbody.AddForce(Vector2.left * speed);
        }

        if (Input.GetKeyDown(jumpKey) && onGround)
        {
            playerRigidbody.AddForce(Vector2.up * jumpStrength);
            onGround = false;
        }

    }

    void changeMagnet()
    {

        Transform MagnetEff = transform.Find("Player_magnet_Effect");
        if (Input.GetKeyDown(changeMagKey))
        {
            if (Time.time > nextMagChangeTime)
            {
                if (playerMagnet == 'B')
                {
                    playerMagnet = 'R';
                    MagnetEff.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0,0.15f);
                    nextMagChangeTime = Time.time + MagChangeCoolDownTime;
                }
                else if (playerMagnet == 'R')
                {
                    playerMagnet = 'B';
                    MagnetEff.GetComponent<SpriteRenderer>().color = new Color(0, 170, 255,0.15f);
                    nextMagChangeTime = Time.time + MagChangeCoolDownTime;
                }
            }
        }
    }

    void specialAbility()
    {

        Transform MagnetEff = transform.Find("Player_magnet_Effect");
        if (Input.GetKeyDown(specialMagKey)){
            if (Time.time > nextSpecialAbilityTime){
                Vector3 tempScale = MagnetEff.localScale;
                MagnetEff.localScale = new Vector3(tempScale.x * abilityStrenth, tempScale.y * abilityStrenth, tempScale.z);

                //MagnetEff.localScale = tempScale;
                nextSpecialAbilityTime = Time.time + AbilityCoolDownTime;
            }
        }
    }

    public void damaged(){
        playerHealth -= 0.2f;
        playerHealthBar.UpdateHealth(playerHealth);
    }

    void die(){
        if(playerStatus == 'D'){
            SceneManager.LoadScene("Gameover");
        }
    }



    private void OnCollisionEnter2D(Collision2D collision){
        onGround = true;
        if(collision.gameObject.tag == "Respawn"){
            RespawnPosition = collision.transform.position;
        }
        if(collision.gameObject.tag == "killer"){
            respawn.Respawn();
        }
    }


}
