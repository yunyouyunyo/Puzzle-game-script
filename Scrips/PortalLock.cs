using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalLock : MonoBehaviour
{
    public string SceneName;
    public BoxTrigger boxTrigger;
    public SimpleLock simpleLock;
    // public int pointNumber;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void  ChangeScene()
    {
        if (!simpleLock.Interactable)
        {
           
                print("change");
                SceneManager.LoadScene(SceneName);
            
        }


    }
}
