using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PillControll : MonoBehaviour
{
    public GameObject pillPrefab;
    void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);
            if (GameObject.FindGameObjectsWithTag("pill").Length < 5)
            {
                float randomX = UnityEngine.Random.Range(-41f, 17f);
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);
                Instantiate(pillPrefab, spawnPosition, Quaternion.identity);
            }
        yield return null;
    }
}

}
