using UnityEngine.SceneManagement;
using UnityEngine;

public class lockforbubble : MonoBehaviour
{
    public bubbleControll bubbleControll;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.tag = "PortalLock4";
    }
    public void ChangeScene()
    {
        if (bubbleControll.doorOpen)
        {

            print("change");
            SceneManager.LoadScene(SceneName);

        }


    }
}
