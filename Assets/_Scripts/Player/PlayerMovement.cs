using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 PlayerPosition { get { return _playerPositon; }}

    [SerializeField] private AudioSource _jumpSound;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _gravityScaler = 2;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float CheckGroundAreaWidth;
    [SerializeField] private float CheckGroundAreaHeight;
    [SerializeField] private float CheckGroundOffSetY;

    private CharacterAnimations _animations;
    private Rigidbody2D _rb;
    private bool _isGrounded;   
    private float _gravityScale;
    private static Transform _playerTransform;
    private static Vector3 _playerPositon;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharacterAnimations>();
        _playerTransform = GetComponent<Transform>();
        _playerPositon = _playerTransform.position;
        _gravityScale = _rb.gravityScale;
    }

    private void FixedUpdate()
    {
        _playerPositon = _playerTransform.position;
        MovementLogic();
        CheckGround();
        JumpLogic();
        FallFaster();
        _animations.IsFlying = IsFlying();
    }
    void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0 ? true : false;
        if (isMoving)
        {
            _spriteRenderer.flipX = moveHorizontal < 0 ? true : false;
        }
        _animations.IsMoving = isMoving;
        Vector2 movement = new Vector2(moveHorizontal * _movementSpeed, _rb.velocity.y);
        _rb.velocity = movement;
    }

    void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0 && _isGrounded == true && _rb.velocity.y == 0f)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animations.Jump();
            _jumpSound.Play();
        }
    }
    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll
            (new Vector3(transform.position.x, transform.position.y + CheckGroundOffSetY, 0), new Vector3(CheckGroundAreaWidth, CheckGroundAreaHeight, 0), 0);

        _isGrounded = colliders.Length > 1 ? true : false;   
    }
    bool IsFlying()
    {
        return _rb.velocity.y < 0 ? true : false;
    }

    void FallFaster()
    {
        if (_isGrounded)
        {
            _rb.gravityScale = _gravityScale;
            return;
        }
        if (Input.GetAxisRaw("Vertical") < 0 )
        {
            _rb.gravityScale = _gravityScale * _gravityScaler;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, CheckGroundOffSetY, 0), new Vector3(CheckGroundAreaWidth, CheckGroundAreaHeight, 0));
    }
}
