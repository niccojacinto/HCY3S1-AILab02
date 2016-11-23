using UnityEngine;
using System.Collections;

public class Idle : Action {

    public Idle(Character _character) : base(_character) {
        actionName = "Idle";
        character.ChangeStatus(actionName);
    }
    public override void LateUpdate () {
	    if (character.IsHealthy()) {
            character.ChangeState(new SearchEnemy(character));
        } else if (!character.IsHealthy()) {
            character.ChangeState(new SearchHealth(character));
        } else if (character.IsTired()) {
            character.ChangeState(new SearchEnergy(character));
        }
	}
}
