using UnityEngine;
using System.Collections;

public class Idle : Action {

    public Idle(Character _character) : base(_character) { }
    public override void LateUpdate() {
        // Just chillin'
        character.ChangeStatus("Idle");
    }
}
