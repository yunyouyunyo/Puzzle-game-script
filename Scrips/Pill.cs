using System;
using UnityEngine;


public class Pill : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            playerHealth.EnterPill();
        }
    }
    public void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.ExitPill();
        }
    }
}
