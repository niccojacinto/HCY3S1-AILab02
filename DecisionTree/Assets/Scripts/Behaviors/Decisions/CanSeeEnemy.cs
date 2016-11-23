using UnityEngine;
using System.Collections;

public class CanSeeEnemy : Decision {

    AIController ai; 

    public CanSeeEnemy(Character _character) : base(_character) {
        nodeTrue = new DangerClose(_character);
        nodeFalse = new CheckHealth(_character);
        ai = _character as AIController;
    }

    private bool CanSee() {
        if (character.DistanceToNearestCharacter() <= ai.visionRange) return true;
        return false;
    }

    public override DecisionTreeNode MakeDecision() {
        if (CanSee()) // If I can see an enemy
            return nodeTrue.MakeDecision(); // 
        return nodeFalse.MakeDecision(); // Otherwise, Check my health
    }
}
