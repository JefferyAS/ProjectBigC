using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMessage : MonoBehaviour
{
    public SerialController serialController;
    public float slowRange=5;
    public float fastRange;
    public LayerMask bombLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DetectBomb();
    }
    public void DetectBomb()
    {
        if (Physics2D.OverlapCircle(transform.position, fastRange, bombLayer))
        {
            Debug.Log("very close");
            serialController.SendSerialMessage("A");

        }else if (Physics2D.OverlapCircle(transform.position, slowRange, bombLayer))
        {
            Debug.Log("close");
            serialController.SendSerialMessage("B");
        }
        else {

            serialController.SendSerialMessage("C");
        }
    }
}
