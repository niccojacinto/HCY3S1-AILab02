using UnityEngine;
using System.Collections;

public class ApproachEnemy : Action
{
    void Start()
    {
        nodeName = "Approach Enemy";
    }

    public override void LateUpdate()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);
        GetComponent<AIController>().MoveTo(Level.playerRef.transform.position);
    }
}
