using UnityEngine;
using System.Collections;

public class AIController : Character {

    protected Action currentBehavior;

	protected override void Start () {
        base.Start();
        currentBehavior = new Idle(GetComponent<Character>());
    }
	
	protected override void Update () {
        base.Update();
        currentBehavior.Update();
	}

    public override void ChangeState(Action action) {
        currentBehavior = action;
    }
}
