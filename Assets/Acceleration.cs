using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acceleration : MonoBehaviour
{
    public float accelerationCoef = 10f;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player")
        {
            print("OOO");
            Rigidbody2D PlayerRb = player.GetComponent<Rigidbody2D>();
            print(gameObject.transform.rotation.eulerAngles);
            Vector2 vec = degreeToVector(gameObject.transform.rotation.eulerAngles.z) * accelerationCoef;
            print(vec);
            if (PlayerRb.velocity.x* vec.x < 0)
            {
                player.isCountDownAcc = true;

            }
            PlayerRb.AddForce(vec, ForceMode2D.Impulse);
        }
    }

    Vector2 degreeToVector(float degree)
    {
        float radians = degree * (Mathf.PI / 180f);
        Vector2 vec =  new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        print(vec);
        return vec;
    }
}
