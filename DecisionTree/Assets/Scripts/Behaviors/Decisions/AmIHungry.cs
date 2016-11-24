using UnityEngine;
using System.Collections;

public class AmIHungry : Decision
{
    public int hunger = 50;

    void Start()
    {
        nodeName = "Am I Hungry";
    }

    public override DecisionTreeNode GetBranch()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);

        if (GetComponent<AIController>().energy < hunger)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}