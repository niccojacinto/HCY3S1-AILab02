using UnityEngine;
using System.Collections;

public class DecisionTree : DecisionTreeNode {

    public Decision root;

    private Decision actionNew;
    private Decision actionOld;

    void Start()
    {
        actionNew = MakeDecision() as Decision;
        actionOld = actionNew;
        actionNew.activated = true;
    }

    public override DecisionTreeNode MakeDecision()
    {
        return root.GetBranch();
    }

    void Update()
    {
        actionNew.activated = false;
        actionOld = actionNew;
        actionNew = root.MakeDecision() as Decision;
        if(actionNew == null)
        {
            actionNew = actionOld;
            actionNew.activated = true;
        }
    }
}
