using UnityEngine;

namespace deflagration {
public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _smoothSpeed = 0.3f;

    [SerializeField]
    private Vector3 _offset;

    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition =  _target.position + _offset;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition,ref _velocity, _smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(_target);
    }
}

}
