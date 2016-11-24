using UnityEngine;
using System.Collections;

public class CanSeeEnemy : Decision {

    public float searchRadius = 10.0f;

    void Start()
    {
        nodeName = "Can I See the Enemy";
    }

    public override DecisionTreeNode GetBranch()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);

        if(Vector3.Distance(transform.position, Level.playerRef.transform.position) < searchRadius)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}
