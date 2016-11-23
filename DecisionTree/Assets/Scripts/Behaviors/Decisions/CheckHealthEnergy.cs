using UnityEngine;
using System.Collections;

public class CheckHealthEnergy : Decision {

	public CheckHealthEnergy(Character _character) : base (_character) {
        nodeTrue = new SearchEnemy(_character);
        nodeFalse = new RandomDecision(new SearchHealth(_character), new SearchEnergy(_character));
    }

    private bool ConditionOK() {
        if (character.IsHealthy() && character.IsHyper()) return true;
        return false;
    }

    public override DecisionTreeNode MakeDecision() {
        if (ConditionOK()) return nodeTrue.MakeDecision();
        return nodeFalse.MakeDecision();
    }
}
