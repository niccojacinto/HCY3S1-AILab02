using UnityEngine;
using System.Collections;

public class AIController : Character {

    protected Action currentBehavior;
    public DecisionTree decisionTree;

	protected override void Start () {
        base.Start();
        decisionTree = GetComponent<DecisionTree>();
        //currentBehavior = new Idle(GetComponent<Character>());
    }
	
	protected override void Update () {
        base.Update();
        //currentBehavior.LateUpdate();
	}

    public override void ChangeState(Action action) {
        //currentBehavior = action;
    }
}
