using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testscript : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float jump_speed = 0.1f;
    private int score = 0;
    private bool isRight = true;
    private bool hasJump = true;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    public TMP_Text tmp_text;
    // private Random rand;

    void Start()
    {
        Debug.Log("start");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1f * Time.deltaTime * speed, 0, 0, Space.World);
            animator.SetBool("is_walking", true);
            if (isRight) {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                isRight = false;
            }

        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0, Space.World);
            animator.SetBool("is_walking", true);
            if (!isRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                isRight = true;
            }
        } else {
            animator.SetBool("is_walking", false); 
        }


        if (Input.GetKey(KeyCode.Space))
        {   
            rb.AddForce(new Vector2(0, jump_speed), ForceMode2D.Impulse);

        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Chest1"))
        {
            Debug.Log("Colided with Chest1");
            Destroy(col.gameObject);
            score += -10;
            tmp_text.text = "Score " + score;
        } else 
        if (col.gameObject.CompareTag("Chest2"))
        {
            Debug.Log("Colided with Chest2");
            Destroy(col.gameObject);
            score += 5;
            tmp_text.text = "Score " + score;
        }

    }


}