using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector2 _move;
    [SerializeField] int jumpPower;
    public int speed;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpPower);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_move * speed, ForceMode2D.Impulse);
    }

    void Flip()
    {
        if (_move.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (_move.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}