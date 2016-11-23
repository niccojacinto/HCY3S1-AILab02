using UnityEngine;
using System.Collections;

public class AIController : Character {

    public float visionRange;
    public float attackRange;
    DecisionTree decisionTree;

	protected override void Start () {
        base.Start();
        attackRange = 1.5f; 
        visionRange = 5.0f; // Warning: Changing this doesnt change the range visual in play mode.
        decisionTree = new DecisionTree(GetComponent<Character>());
    }

    protected override void Update() {
        base.Update();
        decisionTree.Update();
    }
}
