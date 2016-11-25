using UnityEngine;
using System.Collections;

public class Flee : Action {

    void Start()
    {
        nodeName = "Flee";
    }

    Vector3 FleeEnemy()
    {
        return (GetComponent<AIController>().transform.position - Level.playerRef.transform.position);
    }

    public override void LateUpdate()
    {
        //GetComponent<AIController>().ChangeStatus(nodeName);
        GetComponent<AIController>().MoveTo(FleeEnemy());
    }

}
