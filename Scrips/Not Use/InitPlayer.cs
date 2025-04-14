using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitPlayer : MonoBehaviour
{
    public string startScene;
    // Start is called before the first frame update
    void Start()
    {
        if (CheckingInit.debugSceneName == null)
        {
            SceneManager.LoadScene(startScene);
        }else{
            SceneManager.LoadScene(CheckingInit.debugSceneName);
            CheckingInit.debugSceneName=null;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
