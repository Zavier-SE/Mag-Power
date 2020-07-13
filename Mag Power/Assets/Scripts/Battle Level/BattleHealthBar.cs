using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHealthBar : MonoBehaviour
{
    public void UpdateHealth(float health){
        Transform bar = transform.Find("Bar");
        bar.localScale = new Vector3(health, 1f);
    }
}
