using UnityEngine;
using System.Collections;

public class IsEnemyClose : Decision {

    public float nearDistance = 5.0f;

    public override Action GetBranch()
    {
        if (Vector3.Distance(transform.position, Level.playerRef.transform.position) < nearDistance)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}
