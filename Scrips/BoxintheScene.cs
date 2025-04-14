using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxintheScene : MonoBehaviour
{
    public PolygonCollider2D cameraBoundary;
    public Rigidbody2D rb;
    void Update()
    {
         //相機邊界
        float boundaryLeft = cameraBoundary.bounds.min.x+5f;
        float boundaryRight = cameraBoundary.bounds.max.x-5f;

        Vector3 boxPos = rb.transform.position;
        boxPos.x = Mathf.Clamp(boxPos.x, boundaryLeft, boundaryRight);
        rb.transform.position = boxPos;
    }
}
