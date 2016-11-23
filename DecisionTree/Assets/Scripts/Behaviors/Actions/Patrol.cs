using UnityEngine;
using System.Collections;

public class Patrol : Action {

    Transform charTransform;
    Vector3 target;
    Vector3 point;
    float radius = 3.0f;

    public Patrol(Character _character) : base (_character) {
        charTransform = _character.transform;
        target = charTransform.position;
        point = charTransform.position;
    }

    private Vector3 NewPoint() {
        return Level.SGetRandomLocation();
    }

    public override void LateUpdate() {
        point = charTransform.position;
        float distance = Vector3.Distance(target, point);
        if (distance <= 1.0f) {
            target = NewPoint();
        }

        character.MoveTo(target);
        character.ChangeStatus("Patrol");
    }
}
