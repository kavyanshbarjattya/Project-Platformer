using UnityEngine;

public class Enemy_Patrolling : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    [Header("Movement Settings")]
    [SerializeField] float speed = 2f;
    [SerializeField] float waitTimeAtPoint = 0.5f;

    [SerializeField] float _rotateSpeed;

    private Vector3 targetPosition;
    private bool waiting = false;

    private void Start()
    {
        targetPosition = pointB.position;
        transform.position = pointA.position;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + _rotateSpeed * Time.deltaTime);
        if (waiting) return;

        // Move towards target
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        

        // Check if reached
        if (Vector2.Distance(transform.position, targetPosition) < 0.05f)
        {
            StartCoroutine(WaitAndSwitch());
        }
    }

    private System.Collections.IEnumerator WaitAndSwitch()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTimeAtPoint);

        // Swap target
        if (targetPosition == pointA.position)
            targetPosition = pointB.position;
        else
            targetPosition = pointA.position;

        waiting = false;
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawWireSphere(pointA.position, 0.1f);
            Gizmos.DrawWireSphere(pointB.position, 0.1f);
        }
    }
}
