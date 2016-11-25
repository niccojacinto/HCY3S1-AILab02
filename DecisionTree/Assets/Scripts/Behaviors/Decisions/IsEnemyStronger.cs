using UnityEngine;
using System.Collections;

public class IsEnemyStronger : Decision {

    void Start()
    {
        nodeName = "Is the Enemy Stronger";
    }

    public override DecisionTreeNode GetBranch()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);

        if (GetComponent<AIController>().health >= Level.playerRef.GetComponent<PlayerController>().health)
        {
            return nodeFalse;
        }
        else
        {
            return nodeTrue;
        }
    }
}
