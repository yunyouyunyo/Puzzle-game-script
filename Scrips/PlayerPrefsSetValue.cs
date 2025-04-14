using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSetValue : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.tag == "Portal"){
            float playerHp = GetComponent<PlayerHealth>().hp;
            PlayerPrefs.SetFloat("playerHp",playerHp);
        }
    }
}
