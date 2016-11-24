using UnityEngine;
using System.Collections;

public class Attack : Action {

    void Start()
    {
        nodeName = "Attack";
    }

    public override void LateUpdate()
    {
        GetComponent<AIController>().ChangeStatus(nodeName);
        GetComponent<AIController>().AttackForward();
    }
}