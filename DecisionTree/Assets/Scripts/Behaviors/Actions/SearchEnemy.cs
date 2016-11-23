using UnityEngine;
using System.Collections;

public class SearchEnemy : Action {

    public SearchEnemy(Character _character) : base(_character) {
    }

    public override void LateUpdate() {
        character.MoveTo(character.GetNearestCharacter().transform.position);
        character.ChangeStatus("Charge");
    }
}