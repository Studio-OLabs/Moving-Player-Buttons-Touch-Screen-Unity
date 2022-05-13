using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    Rigidbody2D rb2D;
    public Animator heroAnim;
    public float Velocity, Speed, jumpForce;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //Animação do hero estar parada (idle)
        heroAnim.SetBool("Jump", false);
        heroAnim.SetBool("Run", false);
        heroAnim.SetBool("Walk", false);
    }

    // Update is called once per frame
    void Update()
    {
        Move(Speed);
    }

    void Move(float _speed)
    {
        rb2D.transform.Translate(_speed * Time.deltaTime, 0, 0);
        heroAnim.SetBool("Walk", true);

        Flip();
    }

    private void Flip()
    {
        if(Speed < 0)
        {
            if(gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Speed > 0)
        {
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
    public void MoveRight()
    {
        Speed = Velocity;
    }
    public void MoveLeft()
    {
        Speed = -Velocity;
    }
    public void StopMove()
    {
        Speed = 0;
    }
    public void Jump()
    {
        if (canJump)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            heroAnim.SetBool("Jump", true);
        }
 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = false;
        }
    }
}