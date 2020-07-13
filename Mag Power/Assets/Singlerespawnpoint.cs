using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlerespawnpoint : MonoBehaviour
{
    public BasicPlayerControl thePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        BasicPlayerControl thePlayer = FindObjectOfType<BasicPlayerControl>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Player"){
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
          
        }

    }

    public void Respawn(){
        StartCoroutine("RespawnGo");
    }


    public IEnumerator RespawnGo(){  
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        thePlayer.transform.position = thePlayer.RespawnPosition;
        thePlayer.gameObject.SetActive(true);
    }
}
