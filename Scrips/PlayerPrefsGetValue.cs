using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsGetValue : MonoBehaviour
{
    int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        playerHp = PlayerPrefs.GetInt("playerHp");
        GetComponent<PlayerHealth>().hp = playerHp;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Player Hp : "+playerHp);
    }
}
