using UnityEngine;
using System.Collections;

public class IsEnemyClose : Decision {

    public float nearDistance = 2.5f;

    void Start()
    {
        nodeName = "Is the Enemy Close?";

    }

    public override DecisionTreeNode GetBranch()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);

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
