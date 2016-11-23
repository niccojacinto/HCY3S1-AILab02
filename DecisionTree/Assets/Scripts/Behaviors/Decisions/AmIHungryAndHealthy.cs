using UnityEngine;
using System.Collections;

public class AmIHungryAndHealthy : Decision {

    public int hunger = 50;
    public int healthy = 50;

    public override DecisionTreeNode GetBranch()
    {
        if (GetComponent<AIController>().health > healthy && GetComponent<AIController>().energy < hunger)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}
