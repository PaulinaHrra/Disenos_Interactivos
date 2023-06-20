using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Direction direction;
    public List<Transform> tail = new List<Transform>();

    public float frameRate = 0.2f;
    public float step = 0.16f;
    public GameObject tailPrefab;
    public Vector2 horizontalRange;
    public Vector2 verticalRange;

    private Vector3 lastPos;

    void Start()
    {
         InvokeRepeating("Move", frameRate, frameRate);
    }

    void Move()
    {
        lastPos = transform.position;
        Vector3 nextPos = Vector3.zero;

        if (direction == Direction.Up)
            nextPos = Vector3.up;
        else if (direction == Direction.Down)
            nextPos = Vector3.down;
        else if (direction == Direction.Left)
            nextPos = Vector3.left;
        else if (direction == Direction.Right)
            nextPos = Vector3.right;

        nextPos *= step;
        transform.position += nextPos;
        MoveTail();
    }

    void MoveTail()
    {
        for (int i = 0; i < tail.Count; i++)
        {
            Vector3 temp = tail[i].position;
            tail[i].position = lastPos;
            lastPos = temp;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Direction.Up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Direction.Down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.Left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.Right;
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            Debug.Log("Habeis palmado");
            SceneManager.LoadScene(0);
        }
        else if (col.CompareTag("Food"))
        {
            tail.Add(Instantiate(tailPrefab, tail[tail.Count - 1].position, Quaternion.identity).transform);
            col.transform.position = new Vector2(Random.Range(horizontalRange.x, horizontalRange.y), Random.Range(verticalRange.x, verticalRange.y));
        }
    }
}
