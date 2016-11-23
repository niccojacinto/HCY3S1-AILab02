using UnityEngine;
using System.Collections;

public class RandomDecision : Decision {

    private const float decisionDelay = 1.0f;
    private float timer;

	public RandomDecision(Action trueNode, Action falseNode) : base(null) {
        timer = 0.0f;
        nodeTrue = trueNode;
        nodeFalse = falseNode;
    }

    private bool FlipCoin() {
        timer = decisionDelay;
        bool result = Random.Range(0, 2) == 1 ? true : false;
        return result;
    }

	public override DecisionTreeNode MakeDecision () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            if (FlipCoin()) // If the coin is heads
                return nodeTrue.MakeDecision(); // return the first action bound
            return nodeFalse.MakeDecision(); // if its tails, return the second
        }
        return null;
	}
}
