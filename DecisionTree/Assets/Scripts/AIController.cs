using UnityEngine;
using System.Collections;

public class AIController : Character {

    protected Action currentBehavior;

	protected override void Start () {
        base.Start();
        currentBehavior = new Idle(GetComponent<Character>());
    }
	
	protected void Update () {
        base.Update();
        currentBehavior.LateUpdate();
	}

    public override void ChangeState(Action action) {
        currentBehavior = action;
    }
}
