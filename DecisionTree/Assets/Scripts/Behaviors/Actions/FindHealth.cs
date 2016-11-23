using UnityEngine;
using System.Collections;

public class FindHealth : Action {

    //public SearchHealth(Character _character) : base(_character) {
    //    actionName = "Searching for Health";
    //    character.ChangeStatus(actionName);
    //}

    //private Vector3 FindNearestPack() {
    //    Vector3 nearest = Vector3.zero;
    //    float distance = 9999.0f;

    //    foreach (Pickup pickup in Level.allPickups) {
    //        if (pickup == null) continue;

    //        if (pickup is HealthPack) {

    //            float currentDist = Vector3.Distance(character.transform.position, pickup.transform.position);

    //            if (currentDist < distance) {
    //                nearest = pickup.transform.position;
    //                distance = currentDist;
    //            }
    //        }

    //    }

    //    return nearest;
    //}


    //public override void LateUpdate() {
    //    if (!character.IsHealthy())
    //        character.MoveTo(FindNearestPack());
    //    else {
    //        character.ChangeState(new Idle(character));
    //    }
    //}
}
