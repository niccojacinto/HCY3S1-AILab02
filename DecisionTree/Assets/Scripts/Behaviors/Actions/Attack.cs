using UnityEngine;
using System.Collections;

public class Attack : Action {

    //public SearchEnemy(Character _character) : base(_character) {
    //    actionName = "Searching for Enemy";
    //    character.ChangeStatus(actionName);
    //}

    //private Vector3 FindNearestEnemy() {
    //    Vector3 nearest = Vector3.zero;
    //    float distance = 9999.0f;

    //    foreach (Character c in Level.allCharacters) {
    //        if (c == null) continue;

    //        if (c == character) continue;

    //        // Debug.Log(c);

    //        float currentDist = Vector3.Distance(character.transform.position, c.transform.position);

    //        if (currentDist < distance) {
    //            nearest = c.transform.position;
    //            distance = currentDist;
    //        }

    //    }

    //    return nearest;
    //}


    //public override void LateUpdate() {
    //    Vector3 d = FindNearestEnemy();
    //    if (!character.IsHealthy()) character.ChangeState(new SearchHealth(character));
    //    else {
    //        if (Vector3.Distance(character.transform.position, d) <= 2.0) {
    //            character.AttackForward();
    //            character.ChangeStatus("Attacking");
    //        }
    //        else {
    //            character.MoveTo(FindNearestEnemy());
    //            character.ChangeStatus(actionName);
    //        }

    //    }

    //}
}