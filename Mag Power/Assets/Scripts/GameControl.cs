using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
        BattleGameOver();
    }

    public void BattleGameOver(){
        SceneManager.LoadScene("OverScene");
    }

    // public void RaceGameOver(){
    //     SceneManager.LoadScene("OverScene");
    // }

    // public void COOPGameOver(){
    //     SceneManager.LoadScene("OverScene");
    // }

    // public void AdventureGameOver(){
    //     SceneManager.LoadScene("OverScene");
    // }

    // public void TutorialGameOver(){
    //     SceneManager.LoadScene("OverScene");
    // }
    
}
