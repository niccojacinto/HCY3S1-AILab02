using UnityEngine;
using System.Collections;

public class CanSeeEnemy : Decision {

    public float searchRadius = 10.0f;

    public override DecisionTreeNode GetBranch()
    {
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
