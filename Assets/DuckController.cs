using UnityEngine;

public enum DuckActions
{
    NONE, IDLE, MOVE, JUMP
}

public class DuckController : MonoBehaviour
{
    public GameObject duck2;

    public float moveForce = 10;
    [Header("Min and max values:")]
    public Vector2 idleTime = Vector2.zero;
    public Vector2 moveTime = Vector2.zero;
    public Vector2 jumpTime = Vector2.zero;
    public Vector2 jumpForce = Vector2.zero;
    public float jumpForceHorizontalMax = 5;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private DuckActions currentAction = DuckActions.NONE;
    private Rigidbody2D rb;
    private float t = 0;
    private Vector3 moveVector = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //Move();
        if (currentAction == DuckActions.NONE)
        {
            AI_chooseAction();
            return;
        }
        UpdateAction();
        Grow();
    }

    void AI_chooseAction()
    {
        t = 0;
        switch (Random.Range(0, 3))
        {
            case 0: // Idle
                currentAction = DuckActions.IDLE;
                t = Random.Range(idleTime.x, idleTime.y);
                anim.Play("idle");
                break;

            case 1: // Move
                currentAction = DuckActions.MOVE;
                if (Random.Range(0,2) == 0)
                {
                    moveVector = Vector3.right;
                    spriteRenderer.flipX = false;

                }
                else
                {
                    moveVector = Vector3.left;
                    spriteRenderer.flipX = true;
                }
                anim.Play("jump");
                t = Random.Range(moveTime.x, moveTime.y);
                break;

            case 2: // Jump
                currentAction = DuckActions.JUMP;
                rb.AddForce(Vector3.up * Random.Range(jumpForce.x, jumpForce.y), ForceMode2D.Impulse);
                float randomX = Random.Range(-jumpForceHorizontalMax, jumpForceHorizontalMax);
                rb.AddForce(Vector3.right * randomX, ForceMode2D.Impulse);
                if (randomX < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
                anim.Play("walk");
                t = Random.Range(jumpTime.x, jumpTime.y);
                break;

            default: break;
        }
    }

    void UpdateAction()
    {
        switch (currentAction)
        {
            case DuckActions.IDLE: UpdateIdle(); break;
            case DuckActions.MOVE: UpdateMove(); break;
            case DuckActions.JUMP: UpdateJump(); break;
            default: break;
        }

        t -= Time.deltaTime;
        if (t <= 0)
        {
            currentAction = DuckActions.NONE;
        }
    }

    void UpdateIdle()
    {

    }

    void UpdateMove()
    {
        print("move");
        rb.AddForce(moveVector * moveForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    void UpdateJump()
    {

    }

    float growT = 0;
    public float growTimeToNextStage = 5;
    void Grow()
    {
        if (growT < growTimeToNextStage)
        {
            print("growing "+growT);
            growT += Time.deltaTime;
            if (growT >= growTimeToNextStage)
            {
                GrowToNextStage();
            }
        }
    }

    void GrowToNextStage()
    {   
        print("grow to next stg");
        GetComponent<Collider2D>().isTrigger = true;
        var clone = Instantiate(duck2, transform.position, Quaternion.identity);
        clone.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    //void Move()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        print("hey");
    //        rb.AddForce(Vector2.up * moveForce * Time.deltaTime, ForceMode2D.Impulse);
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        rb.AddForce(Vector2.left * moveForce * Time.deltaTime, ForceMode2D.Impulse);
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        rb.AddForce(Vector2.down * moveForce * Time.deltaTime, ForceMode2D.Impulse);
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        rb.AddForce(Vector2.right * moveForce * Time.deltaTime, ForceMode2D.Impulse);
    //    }
    //}

    public void Ate()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, 1);
    }
}
