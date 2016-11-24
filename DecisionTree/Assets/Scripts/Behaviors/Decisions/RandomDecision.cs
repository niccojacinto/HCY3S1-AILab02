using UnityEngine;
using System.Collections;

public class RandomDecision : Decision {

    void Start()
    {
        nodeName = "Random Decision";
    }

    public override DecisionTreeNode GetBranch()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);

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
