using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private BoxCollider2D GroundCollider;
    private float GroundHorizontalLength;
    void Start()
    {
        GroundCollider = GetComponent<BoxCollider2D>();
        GroundHorizontalLength = GroundCollider.size.x;
    }

    void Update()
    {
        if(transform.position.x < -GroundHorizontalLength)
        {
            RepositionBackGround();
        }
    }

    void RepositionBackGround()
    {
        Vector2 GroundOffSet = new Vector2(GroundHorizontalLength * 61f, 0f);

        transform.position = (Vector2)transform.position + GroundOffSet;
    }

}
