using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Config _config;

    private Rigidbody _rigidBody = null;

    private int _numberOfJumps;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.constraints =  RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics.Raycast(transform.position, - Vector3.up, 1f);
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * _config.getMovementSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * _config.getMovementSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if(isGrounded) {
                _numberOfJumps = 1;
                _rigidBody.velocity = Vector3.zero;
                _rigidBody.AddForce(new Vector3(0, _config.getJumpForce, 0));
            } else if (_numberOfJumps < _config.getNumberOfJump) {
                _numberOfJumps++;
                _rigidBody.velocity = Vector3.zero;
                _rigidBody.AddForce(new Vector3(0, _config.getJumpForce, 0));
            }
        }

    }
}
