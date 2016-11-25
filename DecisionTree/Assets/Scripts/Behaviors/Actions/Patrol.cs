using UnityEngine;
using System.Collections;

public class Patrol : Action {

    void Start()
    {
        nodeName = "Patrol";
    }

    public override void LateUpdate()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);
    }

}
