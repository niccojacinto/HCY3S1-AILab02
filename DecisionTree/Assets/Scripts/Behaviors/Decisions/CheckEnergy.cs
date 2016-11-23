using UnityEngine;
using System.Collections;

public class CheckEnergy : Decision {

    public CheckEnergy(Character _character) : base(_character) {
        nodeTrue = new RandomDecision(new Idle(_character), new Patrol(_character));
        nodeFalse = new SearchEnergy(_character);
    }

    public bool IsHyper() {
        return character.IsHyper();
    }

    public override DecisionTreeNode MakeDecision() {
        if (IsHyper()) // If I am full of energy
            return nodeTrue.MakeDecision(); // Flip a coin to decide my action
        return nodeFalse.MakeDecision(); // Otherwise, let me look for energy
    }
}