using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionHit : MonoBehaviour
{
    private  Rigidbody rb;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0,0,speed,ForceMode.Impulse);
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            deflagration.Player p = gameObject.GetComponent(typeof(deflagration.Player)) as deflagration.Player;
            p.killPlayer();
            Debug.Log("touché");
        }
    
    }
}
