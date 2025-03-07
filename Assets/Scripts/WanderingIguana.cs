using UnityEngine;

public class WanderingIguana : MonoBehaviour
{
    private float iguanaSpeed = 3.0f;
    private float obstacleRange = 9.0f;
    private float sphereRadius = 0.75f;
    private Animator anim;
    private float turn = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = iguanaSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine if we're headed for an obstacle (so we can decide if we need to turn) 
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // test for a collision 
        if( Physics.SphereCast(ray, 0.5f, out hit))
        {
            // Is there an obstacle in the way that is close enough to warrant a turn?
            if(hit.distance < obstacleRange)
            {
                //if our turn value is not set (0), we need to decide on a left or right turn
                if( Mathf.Approximately(turn, 0.0f))
                {
                    // flip a coin (0 or 1), 0 means a left turn, 1 means right 
                    turn = Random.Range(0, 2) == 0 ? -0.75f : 0.75f; 
                }

                // blending will cause the Iguana to move forward and turn at the same time.
                // turn quickly, move forward slowly
                Move(turn, 0.1f);
            }
            else // no obstacle, ok to move forward without turning 
            {
                float forwardSpeed = Random.Range(0.05f, 1.0f);
                turn = 0.0f; //set the turn value to 0 (we'll know to pick a new direction when we next turn)

                // no blending happens here since we are not turning. 
                Move(turn, forwardSpeed);
            }
        }
    }

    private void Move(float turn, float forward)
    {
        float dampTime = 0.2f;
        if (anim != null)
        {
            anim.SetFloat("Turn", turn, dampTime, Time.deltaTime);
            anim.SetFloat("Forward", forward, dampTime, Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; //set our gizmo color 
        //determine the range vector (starting at the enemy)
        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;
        //draw a line to show the range vector 
        Debug.DrawLine(transform.position, rangeTest);
        // draw a wire sphere at the point on the end of the range vector 
        Gizmos.DrawWireSphere(rangeTest, sphereRadius);
    }
}
