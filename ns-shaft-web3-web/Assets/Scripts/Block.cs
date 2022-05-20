using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isCelling;
    public bool isLeft;
    public float objMoveSpeed;

    float selfMoveSpeed;
    float fakeTimer;
    float trampolineSpeed = 9f;

    private void Start()
    {
        selfMoveSpeed = GameManager.S.objMoveSpeed;
    }

    private void Update()
    {
        if (!gameObject.activeInHierarchy)
            return;

        if (!isCelling)
            transform.Translate(Vector2.up * selfMoveSpeed * Time.deltaTime);

        if (transform.position.y > 6f)
        {
            if(gameObject.CompareTag("Normal"))
            {
                if(Random.value < 0.2f)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        if(fakeTimer > 0.35f)
        {
            fakeTimer = 0;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("Move");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        //Normal, Conveyor, Fake, Trampoline
        if(!gameObject.CompareTag("Nails") && collision.contacts[0].normal == Vector2.down)
        {
            player.ModifyHealth(1);
            player.currentBlock = GetComponent<BoxCollider2D>();

            if(gameObject.CompareTag("Trampoline"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * trampolineSpeed;
                GetComponentInChildren<Animator>().SetTrigger("Bounce");
            }
        }
        else//Nails, Celling
        {
            if(collision.contacts[0].normal == Vector2.down)
            {
                player.currentBlock = GetComponent<BoxCollider2D>();
                player.ModifyHealth(-3);
            }

            if (collision.contacts[0].normal == Vector2.up)
            {
                player.DisableCurrentBlock();
                player.ModifyHealth(-3);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(gameObject.CompareTag("Conveyor") && collision.contacts[0].normal == Vector2.down)
        {
            Vector2 dir = isLeft ? Vector2.left : Vector2.right;
            collision.gameObject.transform.Translate(dir * objMoveSpeed * Time.deltaTime);
        }

        if (gameObject.CompareTag("Fake") && collision.contacts[0].normal == Vector2.down)
        {
            fakeTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
