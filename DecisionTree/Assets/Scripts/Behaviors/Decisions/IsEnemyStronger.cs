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

        if (Level.playerRef.GetComponent<PlayerController>().health > GetComponent<AIController>().health)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}
