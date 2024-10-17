using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string playerName = "Mariusz pierwszy";

    [SerializeField]
    private float moveSpeed = 1.4f;

    [SerializeField]
    private int health = 3;

    [SerializeField]
    private float jumpPower = 10f;

    [SerializeField]
    private int maxJumps = 2;

    [SerializeField]
    private float raycastDistance = 0.6f;

    [SerializeField]
    private LayerMask groundMask;

    private Rigidbody2D rb;

    private Vector3 moveInput = Vector3.zero;

    private bool isOnGround = false;

    private int jumpCount = 0;

    private bool lastFrameWasGrounded;

    public bool IsGrounded
    {
        get => isOnGround;

        private set
        {

        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    void Update()
    {
        moveInput = GetInput();
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        isOnGround = CheckIfIsOnGround();
    }

    private void Move()
    {
        transform.position += moveInput * Time.deltaTime * moveSpeed;
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
    }

    private Vector3 GetInput()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        return new Vector3(inputX, inputY);
    }

    private bool CheckIfIsOnGround()
    {
        var ground = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundMask); 

        if(lastFrameWasGrounded == false && ground == true)
        {
            jumpCount = 0;
        }


        lastFrameWasGrounded = ground;
        return ground;
    }

    private void Jump()
    {
        if (jumpCount < maxJumps || isOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
        if(jumpCount <= maxJumps)
            jumpCount++;
    }
}
