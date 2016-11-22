using UnityEngine;
using System.Collections;

public class SearchEnergy : Action {

    public SearchEnergy(Character _character) : base(_character) {
        actionName = "Searching for Energy";
        character.ChangeStatus(actionName);
    }

    private Vector3 FindNearestPill() {
        Vector3 nearest = Vector3.zero;
        float distance = 9999.0f;

        foreach (Pickup pickup in Level.allPickups) {
            if (pickup == null) continue;

            if (pickup is EnergyPill) {

                float currentDist = Vector3.Distance(character.transform.position, pickup.transform.position);

                if (currentDist < distance) {
                    nearest = pickup.transform.position;
                    distance = currentDist;
                }
            }

        }

        return nearest;
    }


    public override void Update() {

        if (character.IsTired())
            character.MoveTo(FindNearestPill());
        else {
            character.ChangeState(new Idle(character));
        }
    }
}
