using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameManager.S.objMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if(transform.position.y > 12.5f)
        {
            transform.position = new Vector3(0, -12.5f, 0);
        }
    }
}
