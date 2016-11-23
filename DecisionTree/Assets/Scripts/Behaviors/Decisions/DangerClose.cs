using UnityEngine;
using System.Collections;

public class DangerClose : Decision {

    AIController ai;

    public DangerClose(Character _character) : base ( _character ) {
        nodeTrue = new CompareStrength(_character);
        nodeFalse = new CheckHealthEnergy(_character);
        ai = _character as AIController;
    }

    private bool isWithinAttackRange() {
        if (character.DistanceToNearestCharacter() < ai.attackRange) return true;
        return false;
    }

    public override DecisionTreeNode MakeDecision() {
        if (isWithinAttackRange()) return nodeTrue.MakeDecision();
        return nodeFalse.MakeDecision();
    }
}
