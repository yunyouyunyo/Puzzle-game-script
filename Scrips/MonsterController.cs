using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    int hp=0;
    // Start is called before the first frame update
    void Start()
    {
        hp=3;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0){
            Destroy(this.gameObject);
        }
        
    }
       void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Bullet"){
            hp-=1;
            print(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
