using UnityEngine;
using System.Collections;

public class StandStill : Action {

    void Start()
    {
        nodeName = "Stand Still";
    }

    public override void LateUpdate()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);
    }
}
