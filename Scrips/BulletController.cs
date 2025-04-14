using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float timer=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(0.5f * Time.deltaTime * 60, 0, 0);
        timer-=Time.deltaTime;
        if(timer<=0){
            Destroy(this.gameObject);
        }
    }
}
