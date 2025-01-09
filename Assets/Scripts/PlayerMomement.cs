using UnityEngine;

public class PlayerMomement : MonoBehaviour
{
    [SerializeField]
    private PlayerData data;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    private Vector3 moveInput = Vector3.zero;

    private bool isOnGround = false;

    private int jumpCount = 0;

    private bool lastFrameWasGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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

        animator.SetBool("IsGrounded", isOnGround);
    }

    private void Move()
    {
        transform.position += moveInput * Time.deltaTime * data.MoveSpeed;
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * data.MoveSpeed * Time.deltaTime;
    }

    private Vector3 GetInput()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        animator.SetBool("IsRunning", Mathf.Abs(inputX) > 0.05f);

        if(inputX < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;

        return new Vector3(inputX, inputY);
    }

    private bool CheckIfIsOnGround()
    {
        var ground = Physics2D.Raycast(transform.position, Vector2.down, data.RaycastDistance, data.GroundMask); 

        if(lastFrameWasGrounded == false && ground == true)
        {
            jumpCount = 0;
        }


        lastFrameWasGrounded = ground;
        return ground;
    }

    private void Jump()
    {
        if (jumpCount < data.MaxJumps || isOnGround)
        {
            rb.AddForce(Vector3.up * data.JumpPower, ForceMode2D.Impulse);
        }
        if(jumpCount <= data.MaxJumps)
            jumpCount++;
    }
}
