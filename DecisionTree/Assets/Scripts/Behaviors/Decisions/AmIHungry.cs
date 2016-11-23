using UnityEngine;
using System.Collections;

public class AmIHungry : Decision
{
    public int hunger = 50;

    public override Action GetBranch()
    {
        if(GetComponent<AIController>().energy < hunger)
        {
            return nodeTrue;
        }
        else
        {
            return nodeFalse;
        }
    }
}