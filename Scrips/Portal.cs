using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    public string SceneName;
  
    public SimpleLock3 simpleLock3;
    // public int pointNumber;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.tag = "Portal";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeScene()
    {
        if (!simpleLock3.Interactable)
        {
           
                print("change");
                SceneManager.LoadScene(SceneName);
            
        }


    }
}
