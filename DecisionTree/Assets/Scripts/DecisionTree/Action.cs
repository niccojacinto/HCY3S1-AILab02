using UnityEngine;
using System.Collections;

public class Action : DecisionTreeNode{

    public Action (Character _character) : base (_character) {  }

    public override DecisionTreeNode MakeDecision() {
        return this;
    }

    public virtual void LateUpdate() { }
}
