using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void EnterSet()
    {
        gameObject.SetActive(true);
    }
    public void ExitSet()
    {
        gameObject.SetActive(false);
    }
}
