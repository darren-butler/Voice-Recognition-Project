using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform movementTarget;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int distance = 1;
    [SerializeField] private LayerMask collisionLayer;


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
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movementTarget.position + new Vector3(Input.GetAxisRaw("Horizontal") * distance, 0f, 0f), 0.2f, collisionLayer))
                {
                    movementTarget.position += new Vector3(Input.GetAxisRaw("Horizontal") * distance, 0f, 0f);
                }
            } 
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movementTarget.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * distance, 0f), 0.2f, collisionLayer))
                {
                    movementTarget.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * distance, 0f);
                }
            }
        }
    }
}
