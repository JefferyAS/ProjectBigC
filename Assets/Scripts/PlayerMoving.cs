using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSpeedZero() {
        rb.velocity = Vector2.zero;
    }
    public void SetSpeedFull()
    {
        rb.velocity= new Vector2(0, speed);
    }
}
