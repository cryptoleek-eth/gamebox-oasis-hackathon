using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 4f;
    Rigidbody2D rb;
    Animator anim;
    public LayerMask whatIsGround;
    private float screenCenterX;

    int health;
    public int maxHealth;

    public BoxCollider2D currentBlock;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        maxHealth = TicketManager.GetLifeLengthFromLocal();
        health = maxHealth;
        screenCenterX = Screen.width * 0.5f;
    }

    void Update()
    {
        float h = 0.0f;
        //mobile control
        if (Input.touchCount > 0)
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began)
            {
                if (firstTouch.position.x > screenCenterX)
                {
                    h = 1f;
                }
                else if (firstTouch.position.x < screenCenterX)
                {
                    h = -1f;
                }
            }
        }
        else
        {
            h = 0.0f;
        }

        transform.Translate(Vector2.right * h * moveSpeed * Time.deltaTime);

        if (h != 0)
        {
            transform.localScale = new Vector3(-h, 1, 1);
        }

        anim.SetFloat("Move", Mathf.Abs(h));

        anim.SetBool("isGround", IsGround());

        if (transform.position.y < -10f)
        {
            GameManager.S.GameOver();
        }

        // float h = Input.GetAxisRaw("Horizontal");
        // transform.Translate(Vector2.right * h * moveSpeed * Time.deltaTime);
        // Debug.Log(">>>>>>>>h " + h);

        // if (h != 0)
        // {
        //     transform.localScale = new Vector3(-h, 1, 1);
        // }

        // anim.SetFloat("Move", Mathf.Abs(h));
        // anim.SetBool("isGround", IsGround());

        // if (transform.position.y < -10f)
        // {
        //     GameManager.S.GameOver();
        // }

        // Debug.Log("transform.position.y " + transform.position.y);
    }

    bool IsGround()
    {
        return Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 0.25f, whatIsGround);
    }

    public void ModifyHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        GameManager.S.RenewHealthBar(health);

        if (amount < 0)
        {
            if (health <= 0)
                GameManager.S.GameOver();

            anim.SetTrigger("Hurt");
        }
    }

    public void DisableCurrentBlock()
    {
        currentBlock.enabled = false;
    }
}
