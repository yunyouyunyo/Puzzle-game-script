using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){
            SceneManager.LoadScene("veido3");
        }
    }
}
