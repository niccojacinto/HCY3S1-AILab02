using UnityEngine;
using System.Collections;

public class CompareStrength : Decision {

	public CompareStrength(Character _character) : base(_character) {
        nodeTrue = new Attack(_character);
        nodeFalse = new Flee(_character);
    }

    private bool IsStrongerThanNearest() {
        Character c = character.GetNearestCharacter();
        if (character.IsStrongerThan(c)) return true;
        return false;
    }

    public override DecisionTreeNode MakeDecision() {
        if (IsStrongerThanNearest())
            return nodeTrue.MakeDecision();
        return nodeFalse.MakeDecision();

    }
}
