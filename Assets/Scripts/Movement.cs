using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform movementTarget;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int distance = 10;
    [SerializeField] private LayerMask collisionLayer;
    private float horizontal = 0f;
    private float vertical = 0f;
    public bool isHidden = false;

    private float hideTimer;
    private float hideTime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        movementTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (isHidden)
        {
            if(hideTimer >= 0f)
            {
                hideTimer -= Time.deltaTime;
            }
            else
            {
                isHidden = false;
                Color colour = gameObject.GetComponent<SpriteRenderer>().color;
                colour.a = 1;
                gameObject.GetComponent<SpriteRenderer>().color = colour;
            }
        }


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
        }
        else
        {
            vertical = horizontal = 0;
        }
    }

    public void Hide()
    {
        isHidden = true;
        hideTimer = hideTime;

        Color colour = gameObject.GetComponent<SpriteRenderer>().color;
        colour.a = 0.25f;
        gameObject.GetComponent<SpriteRenderer>().color = colour;

    }

    public void Move(string direction, int distance)
    {
        vertical = horizontal = 0;
        this.distance = distance;
        switch (direction)
        {
            case "up":
                vertical = 1f;
                Debug.Log("moving up");
                break;
            case "down":
                vertical = -1f;
                Debug.Log("moving down");
                break;
            case "left":
                horizontal = -1f;
                Debug.Log("moving left");
                break;
            case "right":
                horizontal = 1f;
                Debug.Log("moving right");
                break;
            default:
                break;
        }
    }
}
