using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private string latesMessage;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(latesMessage);
        if (latesMessage=="1")
        {
            TryJump();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
    }
    public void TryJump()
    {
        rb.velocity = new Vector2(0,1);
    }
    void OnMessageArrived(string msg)
    {
        latesMessage = msg.Trim();
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
