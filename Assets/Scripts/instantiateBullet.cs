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
    private float y;
    
    void Start()
    {

    }

    private IEnumerator ShotInterval()
    {
        shotInterval = Random.Range(0.5f,3.0f);
        Debug.Log(shotInterval);
        shoot = false;
        yield return new WaitForSeconds(shotInterval);
        shoot = true;
    }
    private void FixedUpdate()
    {
        if (shoot){
            StartCoroutine(ShotInterval());
            y = Random.Range(0f,1.0f);
            Transform created = Instantiate(bullet.transform,player.transform.position + new Vector3(0,y,-4),bullet.transform.rotation);
            Destroy(created.gameObject,bulletTime);
        }
        
    }
}
