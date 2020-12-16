using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    private  Rigidbody rb;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float forcey,forcez;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0,0,speed,ForceMode.Impulse);
    }
    /*
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("touché");
        }
    
    }
    */
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            //collision.collider.gameObject.GetComponent<Script>().death();
            Destroy(gameObject);
            Debug.Log("touché");
        }
        if (collision.collider.gameObject.tag == "Movable")
        {
            GameObject col = collision.collider.gameObject;
            col.GetComponent<Rigidbody>().AddForce(0,forcey,forcez,ForceMode.Impulse);
        }
    }
}
