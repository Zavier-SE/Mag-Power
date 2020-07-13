using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changesence : MonoBehaviour
{
    public void changemenu(string scenename){
       Application.LoadLevel(scenename);
   }
}
