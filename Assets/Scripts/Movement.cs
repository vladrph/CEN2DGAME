using UnityEngine;

public class Movement : MonoBehaviour
{
    float _horizontalMove = 2f;
    private float _verticalMove = 2f;
    public float runSpeed = 5f;
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 31;
    [SerializeField] int jumpPower;

    private float _movementX;
    private float _movementY;
    private float _rotationZ;

    public Rigidbody2D mybody;

    private SpriteRenderer _sr;
    private Transform _trans;

    private Animator _anim;
    private bool _isGrounded;
    private string _walkAnimation = "walk";
    private string _jumpAnimation = "jump";
    
    private string _groundTag = "Ground";
    private string _enemyTag = "Zombie";

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        _trans = GetComponent<Transform>();
    }


    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _verticalMove = Input.GetAxisRaw("Vertical");

        Vector2 pos = transform.position;
        pos.x += _horizontalMove * runSpeed * Time.deltaTime;
        pos.y += _verticalMove * runSpeed * Time.deltaTime; // time between every frame 
        transform.position = pos;


        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        _movementY = Input.GetAxisRaw("Vertical");

        Debug.Log("move x value is: " + _movementX);
        Debug.Log("Movement y value is: " + _movementY);
        transform.position += new Vector3(_movementX, _movementY, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (_movementX > 0)
        {
            _anim.SetBool(_walkAnimation, true);
            _sr.flipX = false;
        }
        else if (_movementX < 0)
        {
            _anim.SetBool(_walkAnimation, true);
            _sr.flipX = true;
        }

        else if (_movementY > 0)
        {
            _anim.SetBool(_jumpAnimation, true);
        }
        else

        {
            _anim.SetBool(_walkAnimation, false);
            _sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_groundTag))
        {
            _isGrounded = true;
        }

        if (collision.gameObject.CompareTag(_enemyTag))
        {
            Destroy(gameObject);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonUp("Jump"))
        {
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            _anim.SetBool(_jumpAnimation, true);
        }
        else
        {
            _anim.SetBool(_jumpAnimation, false);
        }
    }

    void FixedUpdate()
    {
        AnimatePlayer();
        PlayerJump();
    }
}