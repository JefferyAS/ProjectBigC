using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBombScript : MonoBehaviour
{
    public float range;
    public LayerMask bombLayer;
    PlayerMoving playerMoving;
    private bool canDefuse;
    public float defuseTime;
    // Start is called before the first frame update
    void Start()
    {
        playerMoving = GetComponent<PlayerMoving>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
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
    private IEnumerator Defuse()
    {
        playerMoving.SetSpeedZero();
        canDefuse = false;
        yield return new WaitForSeconds(defuseTime);
        playerMoving.SetSpeedFull();
        canDefuse = true;
    }
}
