using UnityEngine;
using System.Collections;

public class Decision : DecisionTreeNode {

    public DecisionTreeNode nodeTrue;
    public DecisionTreeNode nodeFalse;

    public virtual DecisionTreeNode GetBranch()
    {
        return null;
    }
}
