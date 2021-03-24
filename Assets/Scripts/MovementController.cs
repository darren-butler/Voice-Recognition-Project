using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform movementTarget;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int distance = 1;
    [SerializeField] private LayerMask collisionLayer;
    private float horizontal = 0f;
    private float vertical = 0f;


    // Start is called before the first frame update
    void Start()
    {
        movementTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementTarget.position, speed*Time.deltaTime);

        if (Vector3.Distance(transform.position, movementTarget.position) <= 0f)
        {
            if (Mathf.Abs(horizontal) == 1f)
            {
                if (!Physics2D.OverlapCircle(movementTarget.position + new Vector3(horizontal * distance, 0f, 0f), 0.2f, collisionLayer))
                {
                    movementTarget.position += new Vector3(horizontal * distance, 0f, 0f);
                }
            } 
            else if (Mathf.Abs(vertical) == 1f)
            {
                if (!Physics2D.OverlapCircle(movementTarget.position + new Vector3(0f, vertical * distance, 0f), 0.2f, collisionLayer))
                {
                    movementTarget.position += new Vector3(0f, vertical * distance, 0f);
                }
            }
        }else
        {
            vertical = horizontal = 0;
        }
    }

    public void Move(string direction)
    {
        vertical = horizontal = 0;
        switch(direction)
        {
            case "up":
                vertical = 1f;
                Debug.Log("moving down...");
                break;
            case "down":
                vertical = -1f;
                Debug.Log("moving down...");
                break;
            case "left":
                horizontal = -1f;
                Debug.Log("moving left...");
                break;
            case "right":
                horizontal = 1f;
                Debug.Log("moving right...");
                break;
            default:
                break;
        }
    }
}
