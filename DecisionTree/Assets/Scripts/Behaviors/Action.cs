using UnityEngine;
using System.Collections;

public class Action {

    protected string actionName;
    protected Character character;

    protected Action(Character _character) {
        character = _character;
    }

	public virtual void Update () {
	
	}
}
