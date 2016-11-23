using UnityEngine;
using System.Collections;

public class DecisionTree : DecisionTreeNode {

    public DecisionTreeNode root;
    private Action actionNew;
    private Action actionOld;

    public DecisionTree(Character _character) : base (_character) {
        root = new CanSeeEnemy(_character);
    }

    public override DecisionTreeNode MakeDecision() {
        return root.MakeDecision();
    }

    public void Update() {
        if (root == null) return;

        actionOld = actionNew;
        actionNew = root.MakeDecision() as Action;
        if (actionNew == null)
            actionNew = actionOld;

        actionNew.LateUpdate();
    }



}
