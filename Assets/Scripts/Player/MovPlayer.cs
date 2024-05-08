using UnityEngine;
using UnityEngine.Events;

public class MovPlayer : MonoBehaviour
{
    public static MovPlayer Instance;

    public float moveSpeed;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public Animator anim;
    public Animator animCap;
    public SpriteRenderer sprite;
    public SpriteRenderer spriteCap;

    public InputManager _inputManager;

    public UnityEvent Walk = new UnityEvent();

    private void Awake()
    {
        if (Instance == null)
        {
            MovPlayer.Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        movePoint.parent = null;
    }

    private void Update()
    {
        var movementCommand = new MovementCommand(transform, movePoint.position, moveSpeed, Time.deltaTime);
        Event_Queue.Instance.QueueCommand(movementCommand);
        

        //bool canMove = Vector3.Distance(transform.position, movePoint.position) == 0f;
        switch (_inputManager.MDiections)
        {
            case Directions.Stay:

                ChangeAnimation(false, false, false);
                break;
            case Directions.Up:

                ChangeAnimation(true, false, false);
                SetNextPosition(new Vector2(0, 1));
                break;
            case Directions.Down:

                ChangeAnimation(false, true, false);
                SetNextPosition(new Vector2(0, -1));
                break;
            case Directions.Left:

                sprite.flipX = false;
                spriteCap.flipX = false;
                ChangeAnimation(false, false, true);
                SetNextPosition(new Vector2(-1, 0));
                break;
            case Directions.Right:

                sprite.flipX = true;
                spriteCap.flipX = true;
                ChangeAnimation(false, false, true);
                SetNextPosition(new Vector2(1,0));

                break;

        }

    }

    private void ChangeAnimation(bool up, bool down, bool sides)
    {
        anim.SetBool("MovLeft", sides);
        animCap.SetBool("MovLeft", sides);

        anim.SetBool("MovDown", down);
        anim.SetBool("MovUp", up);

        animCap.SetBool("MovUp", up);
        animCap.SetBool("MovDown", down);

    }

    private void SetNextPosition(Vector2 direction)
    {
        if (Vector3.Distance(transform.position, movePoint.position) == 0f && !Physics2D.OverlapCircle(movePoint.position + new Vector3(direction.x * 0.16f, direction.y * 0.16f, 0f), .05f, whatStopsMovement))
        {
            movePoint.position += new Vector3(direction.x * 0.16f, direction.y * 0.16f, 0f);
            Walk.Invoke();
        }
    }

    public void SetPosition(Vector3 NewPosition)
    {
        movePoint.position = NewPosition;
        transform.position = NewPosition;

    }
}

