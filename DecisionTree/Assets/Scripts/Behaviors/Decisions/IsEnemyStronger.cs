using UnityEngine;
using System.Collections;

public class IsEnemyStronger : Decision {

    public override DecisionTreeNode GetBranch()
    {
        if(Level.playerRef.health > GetComponent<AIController>().health)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}
