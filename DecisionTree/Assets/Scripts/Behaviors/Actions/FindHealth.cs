using UnityEngine;
using System.Collections;

public class FindHealth : Action {

    void Start()
    {
        nodeName = "Find Health";
    }

    private Vector3 FindNearestPack()
    {
        Vector3 nearest = Vector3.zero;
        float distance = 9999.0f;

        foreach (Pickup pickup in Level.allPickups)
        {
            if (pickup == null) continue;

            if (pickup is HealthPack)
            {

                float currentDist = Vector3.Distance(GetComponent<AIController>().transform.position, pickup.transform.position);

                if (currentDist < distance)
                {
                    nearest = pickup.transform.position;
                    distance = currentDist;
                }
            }

        }

        return nearest;
    }

    public override void LateUpdate()
    {
        GetComponent<AIController>().ChangeStatus(nodeName);
        GetComponent<AIController>().MoveTo(FindNearestPack());
    }
}
