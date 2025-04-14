using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckingInit : MonoBehaviour
{
    public static string debugSceneName;
    public static int startPointNumber;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("player_0");
        if(!GameObject.Find("player_0")){
            SceneManager.LoadScene("game");
            debugSceneName = SceneManager.GetActiveScene().name;
        }
        if(startPointNumber!=0){
            GameObject g = GameObject.Find(startPointNumber.ToString())as GameObject;
            playerObject.transform.position = g.transform.position;
        }
        startPointNumber = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
