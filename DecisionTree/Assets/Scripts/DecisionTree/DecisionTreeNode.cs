using UnityEngine;
using System.Collections;

public class DecisionTreeNode {

    protected Character character;

    public DecisionTreeNode(Character _character) { character = _character; }

	public virtual DecisionTreeNode MakeDecision() {
        return null;
    }
}
