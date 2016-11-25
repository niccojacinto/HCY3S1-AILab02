using UnityEngine;
using System.Collections;

public class DecisionTree : DecisionTreeNode {

    public DecisionTreeNode root;

    private Action actionNew;
    private Action actionOld;

    float elapsed;

    void Start()
    {
        actionNew = TraverseTree();
        actionOld = actionNew;
        actionNew.activated = true;
    }

    public override DecisionTreeNode MakeDecision()
    {
        return root.MakeDecision();
    }

    void Update()
    {
        elapsed += Time.deltaTime;

        if(elapsed >= 0.0f)
        {
            actionNew.activated = false;
            actionOld = actionNew;
            actionNew = TraverseTree();
            if (actionNew == null)
            {
                actionNew = actionOld;
                actionNew.activated = true;
            }
            elapsed = 0f;
        }
    }

    public Action GetAction()
    {
        return actionNew;
    }

    Action TraverseTree()
    {
        DecisionTreeNode action = root.MakeDecision();

        while(action as Decision)
        {
            action = action.MakeDecision();
        }

        GetComponent<Character>().ChangeStatus(action.nodeName);

        return action as Action;
    }
}
