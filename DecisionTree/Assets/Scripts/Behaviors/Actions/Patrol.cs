using UnityEngine;
using System.Collections;

public class Patrol : Action {

    public float patrolDistance = 15.0f;
    float elapsed = 0f;

    void Start()
    {
        nodeName = "Patrol";
    }

    // wander helper func
    public static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        return randDirection;
    }

    public override void LateUpdate()
    {
        elapsed += Time.deltaTime;
        if(elapsed >=  1.0f)
        {
            GetComponent<AIController>().MoveTo(RandomNavSphere(gameObject.transform.position, patrolDistance));
            elapsed = 0f;
        }
    }
}
