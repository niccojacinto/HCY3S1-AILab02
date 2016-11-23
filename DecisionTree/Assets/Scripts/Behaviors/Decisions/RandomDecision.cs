using UnityEngine;
using System.Collections;

public class RandomDecision : Decision {

    public override DecisionTreeNode GetBranch()
    {
        if (Random.Range(0, 2) == 0)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}
