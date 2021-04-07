using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // GameObject player;
    private Rigidbody2D playerObject;
    private BoxCollider2D playerCollider;

    //Layermasks for raycasting/boxcasting
    [SerializeField] private LayerMask tilemapLayerMask;
    [SerializeField] private LayerMask pushableLayerMask;

    //Movement
    public float speed;
    public float jump;
    public float moveScale;
    float moveVelocity;

    //Animator variables
    public bool facingRight = true;

    public Animator anim;

    //Called before first frame update
    void Start()
    {
        //Stores our player object into a private variable
        playerObject = this.gameObject.GetComponent<Rigidbody2D>();
        playerCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    // void FixedUpdate()
    // {
    //     float xMove = Input.GetAxis("Horizontal");

    //     if (playerObject.velocity.magnitude < speed)
    //     {
    //         Vector2 movement = new Vector2(xMove, 0);
    //         playerObject.AddForce(moveScale * movement);
    //     }

    //     if (Input.GetButtonDown("Jump") && onGround)
    //     {
    //         Vector2 jumpForce = new Vector2(0, jump);
    //         playerObject.AddForce(jumpForce);
    //     }
    // }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && onGround())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
        }
        moveVelocity = 0;
        if (!onGround())
        {
            if (facingRight)
            {
                anim.SetTrigger("FlyRight");
            }
            else
            {
                anim.SetTrigger("FlyLeft");
            }
        }
        //Left Right Movement
        if (Input.GetKey(KeyCode.A))
        {
            facingRight = false;
            if (isPushing())
            {
                anim.SetTrigger("ScratchLeft");
                moveVelocity = -speed * .5f;
                Debug.Log("is pushing");
            }
            else
            {
                moveVelocity = -speed;
                anim.SetTrigger("FlyLeft");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            facingRight = true;
            if (isPushing())
            {
                moveVelocity = speed * .5f;
            }
            else
            {
                moveVelocity = speed;
                anim.SetTrigger("FlyRight");

            }
        }
        else if (moveVelocity == 0 && onGround())
        {
            if (facingRight)
            {
                anim.SetTrigger("IdleRight");
            }
            else
            {
                anim.SetTrigger("IdleLeft");
            }
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }

    public void fireAnim()
    {
        if (facingRight)
        {
            anim.SetTrigger("FireRight");
        }
        else
        {
            anim.SetTrigger("FireLeft");
        }
    }
    public void endAnimation()
    {
        if (onGround())
        {
            if (facingRight)
            {
                anim.SetTrigger("IdleRight");
            }
            else
            {
                anim.SetTrigger("IdleLeft");
            }
        }
        else
        {
            if (facingRight)
            {
                anim.SetTrigger("FlyRight");
            }
            else
            {
                anim.SetTrigger("FlyLeft");
            }
        }
    }

    private bool onGround()
    {
        //float value determining how much below the player the boxcast extends to check for ground
        float extra = .1f;

        //creates a RaycastHit2D for the boxcast (an object that returns information about the object the cast hits)
        RaycastHit2D hit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, extra, tilemapLayerMask);

        //debug that draws lines of the box cast, and turns green when hitting, red when not hitting
        Color rayColor;
        if (hit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerCollider.bounds.center + new Vector3(playerCollider.bounds.extents.x, 0), Vector2.down * (playerCollider.bounds.extents.y + extra), rayColor);
        Debug.DrawRay(playerCollider.bounds.center - new Vector3(playerCollider.bounds.extents.x, 0), Vector2.down * (playerCollider.bounds.extents.y + extra), rayColor);

        //this will return true if the ray is being broken
        return hit.collider != null;
    }

    private bool isPushing()
    {
        //float value determining how much in front of the player the boxcast extends to check for pushables
        float extra = .01f;

        //hit for boxcast on right of player
        RaycastHit2D hitRight = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.right, extra, pushableLayerMask);

        //hit for boxcast on left of player
        RaycastHit2D hitLeft = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.right, extra, pushableLayerMask);

        //returns true if the player is touching a pushable on either side
        return (hitRight.collider != null || hitLeft.collider != null);
    }

    //Managing collisions with certain objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (CollisionIsWithGround(collision))
        // {
        //     onGround = true;
        // }
    }

    //Managing collision exits with certain objects
    void OnCollisionExit2D(Collision2D collision)
    {
        // if (!CollisionIsWithGround(collision))
        // {
        //     onGround = false;
        // }
    }

    // ***OLD*** Helper function for detecting ground
    // private bool CollisionIsWithGround(Collision2D collision)
    // {
    //     bool is_with_ground = false;
    //     // if (collision.gameObject.tag == "Tilemap")
    //     // {
    //     foreach (ContactPoint2D c in collision.contacts)
    //     {
    //         Vector2 collision_direction_vector = c.point - playerObject.position;
    //         if (collision_direction_vector.y < 0)
    //         {
    //             is_with_ground = true;
    //         }
    //     }
    //     // }
    //     return is_with_ground;
    // }
}
