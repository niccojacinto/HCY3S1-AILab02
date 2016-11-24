using UnityEngine;
using System.Collections;

public class AmIHealthy : Decision
{
    public int healthy = 50;

    void Start()
    {
        nodeName = "Am I Healthy";
    }

    public override DecisionTreeNode GetBranch()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);

        if (GetComponent<AIController>().health > healthy)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}