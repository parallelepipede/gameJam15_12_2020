using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateBullet : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletTime;
    
    private float shotInterval;
    private bool shoot = true;
    
    void Start()
    {
        
    }

    private IEnumerator ShotInterval()
    {
        shotInterval = Random.Range(4.0f,8.0f);
        Debug.Log(shotInterval);
        shoot = false;
        yield return new WaitForSeconds(shotInterval);
        shoot = true;
    }
    private void FixedUpdate()
    {
        if (shoot){
            StartCoroutine(ShotInterval());
            Instantiate(bullet.transform,player.transform.position + new Vector3(0,1,-4),bullet.transform.rotation);
        }
        
    }
}
