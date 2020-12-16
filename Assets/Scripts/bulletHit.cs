using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    private  Rigidbody rb;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0,0,speed,ForceMode.Impulse);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            //collision.collider.gameObject.GetComponent<Script>().death();
            Destroy(gameObject);
            Debug.Log("touché");
        }
    }
}
