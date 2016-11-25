using UnityEngine;
using System.Collections;

public class AmIHungryAndHealthy : Decision {

    public int hunger = 50;
    public int healthy = 50;

    void Start()
    {
        nodeName = "Am I Hungry & Healthy";
    }

    public override DecisionTreeNode GetBranch()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);

        if (GetComponent<AIController>().health > healthy && GetComponent<AIController>().energy > hunger)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}
