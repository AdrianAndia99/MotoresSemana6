using System.Collections;
using UnityEngine;

public class NPCmovimiento : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float movementSpeed = 3f;
    private int currentPatrolIndex = 0;

    private void Start()
    {
        transform.position = patrolPoints[currentPatrolIndex].position;
        StartCoroutine(MoveToNextPatrolPoint());
    }

    private IEnumerator MoveToNextPatrolPoint()
    {
        while (true)
        {
            Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                yield return new WaitForSeconds(1f);
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }

            yield return null;
        }
    }
}