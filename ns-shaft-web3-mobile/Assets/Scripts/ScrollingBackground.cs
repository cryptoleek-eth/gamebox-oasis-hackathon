using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameManager.GetObjMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if (transform.position.y > 11f)
        {
            transform.position = new Vector3(0, -13.5f, 0);
        }
    }
}
