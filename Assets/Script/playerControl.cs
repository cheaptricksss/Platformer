using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMove;
    public float movementMultiplier;

    //check if the pc is grounded
    private bool grounded;
    public float castDistance = 1f;

    //for jumping
    public float jumpLimit = 100f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    private bool jump = false;

    Animator anim;


    //for sprinting
    // private bool isWalking = false;
    public float sprintMultiplier = 1.2f;
    private bool toStartSprint = true;
    private string sprintKey = "z";


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        grounded = true;
        

    }

    // Update is called once per frame
    //tired to fps
    void Update()
    {
        //Debug.Log(Input.GetKeyDown(sprintKey));
        Debug.Log(toStartSprint);
        Debug.DrawRay(GetComponent<Transform>().position, new Vector3(0, castDistance*-1, 0), Color.red, 1f, false);
        horizontalMove = Input.GetAxis("Horizontal");
        //jumping
        if (Input.GetButtonDown("Jump") && grounded) //jump default to space
        {
            jump = true;
        }

        // where the player can start sprinting
        if (Input.GetKeyDown(sprintKey))
        {
            if (grounded == true)
            {
                toStartSprint = true;
            }
            else
            {
                toStartSprint = false;
            }
        }


        // sprint
        if (toStartSprint == true)
        {
            if (Input.GetKey(sprintKey))
            {
                sprintMultiplier = 1.8f;
            }

            else
            {
                sprintMultiplier = 1;
            }
        }

        if (Input.GetKeyUp(sprintKey))
        {
            toStartSprint = false;
        }

    }

    // if the player y position is smaller than -25, teleport him to the start



    //physics always calculated on FixedUpdate
    //no input things in FixedUpdate
    private void FixedUpdate()
    {
        HorizontalMove(horizontalMove);

        if (jump)
        {
            rb.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse); //impulse apply the impulse force instantly.
            jump = false;
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = gravityFall;
        }

        
        //hello
        //Physics.RayCast(Origin, direction, maxDistance)
        //Scripting API: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
        //Vector2.down = Vector2(0, -1) (shorthand version)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDistance); //An inbuild physics function.
                                                                                              //Debug.DrawRay(transform.position, Vector2.down*castDistance, new Color(255,0,0));
        //Debug.Log(hit.transform.name);
        //moving player to layer-> Ignored RayCast so the Log does not print player name
        if (hit.collider != null && hit.collider.tag == "floor")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }


    }

    void HorizontalMove(float toMove)
    {
        float moveX = toMove * Time.fixedDeltaTime * movementMultiplier*sprintMultiplier; //the time that fixed update is running
        rb.velocity = new Vector3(moveX, rb.velocity.y);
        if (rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}

//player jumping. On the ground jumping.
    //check the player is on the ground.
        //RayCasting: draw a ray, goes down, detect if the player is on the ground.
