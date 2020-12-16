using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    namespace deflagration {
    public class Player : MonoBehaviour
    {

        [SerializeField]
        private ConfigPlayer _config;

        private Animator _animator;

        private Rigidbody _rigidBody = null;

        private int _numberOfJumps;

        private float _x;

        // Start is called before the first frame update
        void Start()
        {
            _x = transform.position.x;
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.constraints =  RigidbodyConstraints.FreezeRotation;
        }

        public void killPlayer() {
            Debug.Log("The player is dead");
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(_x, transform.position.y, transform.position.z);
            bool isGrounded = Physics.Raycast(transform.position, - Vector3.up, 0.2f);
            if (Input.GetKey(KeyCode.LeftArrow)) {
                _animator.SetBool("isRunning", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position += new Vector3(0, 0, -1) * Time.deltaTime * _config.getMovementSpeed;
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                _animator.SetBool("isRunning", true);
                transform.rotation =  Quaternion.Euler(0, 0, 0);
                transform.position += new Vector3(0, 0, 1) * Time.deltaTime * _config.getMovementSpeed;
            } else {
                _animator.SetBool("isRunning", false);
            }

            if (isGrounded) {                    
                _animator.SetBool("isJumping", false);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                if(isGrounded) {
                    _numberOfJumps = 1;
                    _rigidBody.velocity = Vector3.zero;
                    _rigidBody.AddForce(new Vector3(0, _config.getJumpForce, 0));
                    _animator.SetBool("isJumping", true);
                } else if (_numberOfJumps < _config.getNumberOfJump) {
                    _numberOfJumps++;
                    _rigidBody.velocity = Vector3.zero;
                    _rigidBody.AddForce(new Vector3(0, _config.getJumpForce, 0));
                    _animator.SetBool("isJumping", true);
                }
            }

        }
    }

}
