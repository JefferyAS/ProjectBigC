using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTrigger : MonoBehaviour
{
    public SerialController serialController;
    public int objectNums;
    public bool entered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectNums>0)
        {
            serialController.SendSerialMessage("A");
            Debug.Log("Sended messages");
        }
        else
        {
            serialController.SendSerialMessage("B");
        }
        //Debug.Log(objectNums);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        objectNums += 1;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        objectNums -= 1;
    }

}
