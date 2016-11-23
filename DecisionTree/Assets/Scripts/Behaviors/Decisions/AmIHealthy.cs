using UnityEngine;
using System.Collections;

public class AmIHealthy : Decision
{

    public int healthy = 50;

    public override Action GetBranch()
    {
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