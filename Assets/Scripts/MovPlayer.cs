using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {
            float movementH = Input.GetAxisRaw("Horizontal");
            float movementV = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(movementH) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movementH * 0.16f, 0f, 0f), .05f, whatStopsMovement))
                {
                    Walk.Invoke();
                    movePoint.position += new Vector3(movementH * 0.16f, 0f, 0f);

                }
            }
            else if (Mathf.Abs(movementV) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movementV * 0.16f, 0f), .05f, whatStopsMovement))
                {
                    Walk.Invoke();
                    movePoint.position += new Vector3(0f, movementV * 0.16f, 0f);
                }


            }
        }

        switch(_inputManager.MDiections)
        {
            case Directions.Stay:

                anim.SetBool("MovLeft", false);
                animCap.SetBool("MovLeft", false);

                anim.SetBool("MovDown", false);
                anim.SetBool("MovUp", false);

                animCap.SetBool("MovUp", false);
                animCap.SetBool("MovDown", false);
                break;
            case Directions.Up:
                anim.SetBool("MovDown", false);
                anim.SetBool("MovUp", true);

                animCap.SetBool("MovDown", false);
                animCap.SetBool("MovUp", true);

                anim.SetBool("MovLeft", false);
                animCap.SetBool("MovLeft", false);
                break;
            case Directions.Down:
                anim.SetBool("MovUp", false);
                anim.SetBool("MovDown", true);

                animCap.SetBool("MovUp", false);
                animCap.SetBool("MovDown", true);

                anim.SetBool("MovLeft", false);
                animCap.SetBool("MovLeft", false);
                break;
            case Directions.Left:
                sprite.flipX = false;
                spriteCap.flipX = false;
                anim.SetBool("MovLeft", true);
                animCap.SetBool("MovLeft", true);


                anim.SetBool("MovDown", false);
                anim.SetBool("MovUp", false);

                animCap.SetBool("MovUp", false);
                animCap.SetBool("MovDown", false);
                break;
            case Directions.Right:
                sprite.flipX = true;
                spriteCap.flipX = true;
                anim.SetBool("MovLeft", true);
                animCap.SetBool("MovLeft", true);


                anim.SetBool("MovDown", false);
                anim.SetBool("MovUp", false);

                animCap.SetBool("MovUp", false);
                animCap.SetBool("MovDown", false);
                break;

        }

    }

    public void SetPosition(Vector3 NewPosition)
    {
        movePoint.position = NewPosition;
        transform.position = NewPosition;

    }
}
