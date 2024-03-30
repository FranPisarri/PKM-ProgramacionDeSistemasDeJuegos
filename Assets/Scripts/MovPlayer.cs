using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MovPlayer : MonoBehaviour
{
    public static MovPlayer Instance;
    public Camera Camera;
    public CinemachineVirtualCamera VirtualCamera;

    public float moveSpeed;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public Animator anim;
    public Animator animCap;
    public SpriteRenderer sprite;
    public SpriteRenderer spriteCap;

    private void Awake()
    {
        if (Instance == null)
        {
            MovPlayer.Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(Camera);
            DontDestroyOnLoad(VirtualCamera);

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
                    movePoint.position += new Vector3(movementH * 0.16f, 0f, 0f);
                }
            }
            else if (Mathf.Abs(movementV) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movementV * 0.16f, 0f), .05f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, movementV * 0.16f, 0f);
                }


            }


            if (movementH < 0f)
            {
                sprite.flipX = false;
                spriteCap.flipX = false;
                anim.SetBool("MovLeft", true);

                animCap.SetBool("MovLeft", true);
            }
            else if (movementH > 0)
            {
                sprite.flipX = true;
                spriteCap.flipX = true;
                anim.SetBool("MovLeft", true);

                animCap.SetBool("MovLeft", true);
            }
            else
            {
                anim.SetBool("MovLeft", false);

                animCap.SetBool("MovLeft", false);
            }

            if (movementV < 0f)
            {
                anim.SetBool("MovUp", false);
                anim.SetBool("MovDown", true);

                animCap.SetBool("MovUp", false);
                animCap.SetBool("MovDown", true);
            }
            else if (movementV > 0)
            {
                anim.SetBool("MovDown", false);
                anim.SetBool("MovUp", true);

                animCap.SetBool("MovDown", false);
                animCap.SetBool("MovUp", true);
            }
            else
            {
                anim.SetBool("MovDown", false);
                anim.SetBool("MovUp", false);

                animCap.SetBool("MovUp", false);
                animCap.SetBool("MovDown", false);
            }
        }/*
        else
        {
            anim.SetBool("MovDown", false);
            anim.SetBool("MovUp", false);
            anim.SetBool("MovLeft", false);
        }*/
        

    }

    public void SetPosition(Vector3 NewPosition)
    {
        transform.position = NewPosition;
        movePoint.position = NewPosition;

    }
}
