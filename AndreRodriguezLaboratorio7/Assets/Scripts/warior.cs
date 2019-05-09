using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warior : MonoBehaviour
{
    Rigidbody2D rb;
    bool enelaire;
    bool powerup = false;
    public Sprite nsprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enelaire = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Input.GetButtonDown("Jump") && rb && enelaire == true)
        {
            enelaire = false;
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }
        Vector2 newPos = transform.position;
        Vector2 newScale = transform.localScale;
        newPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * 5;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (newScale.x > 0)
            {
                newScale.x = -newScale.x;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (newScale.x < 0)
            {
                newScale.x = -newScale.x;
            }
        }
        transform.localScale = newScale;
        transform.position = newPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) enelaire = true;
        if (collision.gameObject.CompareTag("power"))
        {
            Destroy(collision.gameObject);
            powerup = true;
            GetComponent<SpriteRenderer>().sprite = nsprite;
            transform.localScale = new Vector2(0.6f, 0.6f);
            Destroy(GetComponent<BoxCollider2D>());
            gameObject.AddComponent<BoxCollider2D>();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (powerup) Destroy(collision.gameObject);
            else Destroy(gameObject);
        }
    }
}
