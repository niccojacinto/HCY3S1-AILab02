using UnityEngine;
using System.Collections;

public class CheckHealth : Decision {

    public CheckHealth (Character _character) : base(_character) {
        nodeTrue = new CheckEnergy(_character);
        nodeFalse = new SearchHealth(_character);
    }

    public bool IsHealthy() {
        return character.IsHealthy();
    }

    public override DecisionTreeNode MakeDecision() {
        if (IsHealthy()) // If I am healthy
            return nodeTrue.MakeDecision(); // Let me check my energy
        return nodeFalse.MakeDecision(); // Otherwise, I'm gonna look for health
    }
}
