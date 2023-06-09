using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject startNode;


    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPos = new Vector2(-0.06f, -0.65f);

        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        movementController = GetComponent<MovementController>();
        startNode = movementController.currentNode;

    }

    public void Setup()
    {
        movementController.currentNode = startNode;
        movementController.lastMovingDirection = "left";
        transform.position = startPos;
        animator.SetBool("moving", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameIsRunning)
        {
            return;
        }

        animator.SetBool("moving", true);
        if (Input.GetKey(KeyCode.A))
        {
            movementController.SetDirection("left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementController.SetDirection("right");
        }
        if (Input.GetKey(KeyCode.W))
        {
            movementController.SetDirection("up");
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementController.SetDirection("down");
        }

        bool flipX = false;
        bool flipY = false;
        if (movementController.lastMovingDirection == "left")
        {
            animator.SetInteger("direction", 0);
        }
        else if (movementController.lastMovingDirection == "right")
        {
            animator.SetInteger("direction", 0);
            flipX = true;
        }
        else if (movementController.lastMovingDirection == "up")
        {
            animator.SetInteger("direction", 1);
        }
        else if (movementController.lastMovingDirection == "down")
        {
            animator.SetInteger("direction", 1);
            flipY = true;
        }

        sprite.flipY = flipY;
        sprite.flipX = flipX;
    }
}