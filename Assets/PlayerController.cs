using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private float height;
    private float width;
    private float sizeBuffer = 0.02f;
    public float jumpForce = 5.0f;
    public float velocityX = 3f;
    public float scalingSpeed = 1f;
    public float scalingMass = 0.5f;
    public float scalingJump = 0.6f;
    public float minScale = 0.4f;
    public float maxScale = 3f;
    public float minMass = 0.3f;
    public float maxMass = 3f;
    private float velocityOrientationMultiplier = 1;
    private Vector3 prevPosition;


    private RaycastHit2D wallHit = new();

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        height = circleCollider.radius + sizeBuffer;
        width = circleCollider.radius + sizeBuffer;

    }

    // Start is called before the first frame update
    void Start()
    {
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // check wall hit
        if (velocityOrientationMultiplier == 1){
            wallHit = Physics2D.Raycast(rb.position, Vector2.right, width, LayerMask.GetMask("Wall"));
            if (wallHit.collider != null){
                AudioManager.PlaySound("ball_hit");

                velocityOrientationMultiplier = -1;
            }
        }
        else{
            wallHit = Physics2D.Raycast(rb.position, Vector2.left, width, LayerMask.GetMask("Wall"));
            if (wallHit.collider != null){
                AudioManager.PlaySound("ball_hit");

                velocityOrientationMultiplier = 1;
            }
        }

        
        rb.velocity = new Vector2(velocityX * velocityOrientationMultiplier, rb.velocity.y);
        // Vector3 MoveVector = new Vector3(velocityX * velocityOrientationMultiplier * Time.deltaTime, 0, 0);
        // // print((prevPosition - (transform.position + MoveVector)).magnitude);
        // if ((prevPosition - (transform.position + MoveVector)).magnitude > 0.05)
        // {
        //     transform.position += MoveVector;
        //     prevPosition = transform.position;
        // }





        if (Input.GetKeyDown(KeyCode.Space)){
            JumpTry();
        }    

        // scaling sounds
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            AudioManager.PlaySound("ball_shrinking");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)){
            AudioManager.StopDefaultSound();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)){
            AudioManager.PlaySound("ball_expanding");
        }
        if (Input.GetKeyUp(KeyCode.Mouse1)){
            AudioManager.StopDefaultSound();
        }


        // left mouse button scales player down
        if (Input.GetKey(KeyCode.Mouse0) && transform.localScale.x > minScale){
            // print(scalingSpeed);
            transform.localScale *= 1 - scalingSpeed* Time.deltaTime;
            height *= 1 - scalingSpeed * Time.deltaTime;
            width *= 1 - scalingSpeed * Time.deltaTime;
            rb.mass *= 1 - scalingMass * Time.deltaTime;
            jumpForce *= 1 - scalingJump * Time.deltaTime;
            // print(scalingSpeed);
            // print(scalingMass);
        }

        // right mouse button scales player up
        if (Input.GetKey(KeyCode.Mouse1) && transform.localScale.x < maxScale){
            transform.localScale *= 1 + scalingSpeed* Time.deltaTime;
            height *= 1 + scalingSpeed *Time.deltaTime;
            width *= 1 + scalingSpeed * Time.deltaTime;
            rb.mass *= 1 + scalingMass * Time.deltaTime;
            jumpForce *= 1 + scalingJump * Time.deltaTime;
            // print(rb.mass);
        }

    }

    private void JumpTry()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, height, LayerMask.GetMask("Ground"));

        // print("try jump height (max distance to trigger the jump) = " + height);
        if (hit.collider != null){
            AudioManager.PlaySound("jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
