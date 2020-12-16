using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Config", order = 1)]
public class ConfigPlayer : ScriptableObject
{
    [SerializeField]
    private float _movementSpeed;

    public float getMovementSpeed => _movementSpeed;

    [SerializeField]
    private float _numberOfJump;
    
    public float getNumberOfJump => _numberOfJump;

    [SerializeField]
    private float _jumpForce;
    
    public float getJumpForce => _jumpForce;


}