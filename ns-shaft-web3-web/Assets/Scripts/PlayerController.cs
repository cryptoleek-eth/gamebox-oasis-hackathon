using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Animator anim;

    public LayerMask whatIsGround;
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
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
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
