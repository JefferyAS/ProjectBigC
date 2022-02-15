using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBombScript : MonoBehaviour
{
    public float range;
    public LayerMask bombLayer;
    PlayerMoving playerMoving;
    private bool canDefuse=true;
    public float defuseTime;
    public string latesMessage;
    // Start is called before the first frame update
    void Start()
    {
        playerMoving = GetComponent<PlayerMoving>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(latesMessage);
        if (canDefuse&&latesMessage == "1")
        {
            RemoveBomb();
        }
    }
    public void RemoveBomb()
    {
        Collider2D bomb= Physics2D.OverlapCircle(transform.position,range,bombLayer);
        if (bomb != null)
        {
            Destroy(bomb.gameObject);
        }
        StartCoroutine(Defuse());
    }
    void OnMessageArrived(string msg)
    {
        latesMessage = msg.Trim();
    }
    private IEnumerator Defuse()
    {
        playerMoving.SetSpeedZero();
        canDefuse = false;
        yield return new WaitForSeconds(defuseTime);
        playerMoving.SetSpeedFull();
        canDefuse = true;
    }
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
