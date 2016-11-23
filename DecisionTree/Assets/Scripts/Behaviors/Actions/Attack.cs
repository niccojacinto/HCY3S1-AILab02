using UnityEngine;
using System.Collections;

public class Attack : Action {

	public Attack(Character _character) : base (_character) {  }

    public override void LateUpdate() {
        character.AttackForward();
        character.ChangeStatus("Attack");
    }
}
