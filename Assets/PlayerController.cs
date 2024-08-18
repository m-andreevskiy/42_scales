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
    public float scalingSpeed = 0.01f;
    public float minScale = 0.3f;
    public float maxScale = 3f;
    private int velocityOrientationMultiplier = 1;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        wallHit = Physics2D.Raycast(rb.position, Vector2.right, width, LayerMask.GetMask("Wall"));
        if (wallHit.collider != null){
            velocityOrientationMultiplier = -1;
        }

        wallHit = Physics2D.Raycast(rb.position, Vector2.left, width, LayerMask.GetMask("Wall"));
        if (wallHit.collider != null){
            velocityOrientationMultiplier = 1;
        }
        transform.position += new Vector3(velocityX * velocityOrientationMultiplier * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)){
            JumpTry();
        }    




        // left mouse button scales player down
        if (Input.GetKey(KeyCode.Mouse0) && transform.localScale.x > minScale){
            transform.localScale *= 1 - scalingSpeed;
            height *= 1 - scalingSpeed;
            width *= 1 - scalingSpeed;
        }

        // right mouse button scales player up
        if (Input.GetKey(KeyCode.Mouse1) && transform.localScale.x < maxScale){
            transform.localScale *= 1 + scalingSpeed;
            height *= 1 + scalingSpeed;
            width *= 1 + scalingSpeed;
        }
    }

    private void JumpTry()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, height, LayerMask.GetMask("Ground"));

        // print("try jump height (max distance to trigger the jump) = " + height);
        if (hit.collider != null){
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
