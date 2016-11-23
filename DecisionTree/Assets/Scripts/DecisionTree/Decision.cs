using UnityEngine;
using System.Collections;

public class Decision : DecisionTreeNode {

    public Decision (Character _character) : base (_character) { }

    public DecisionTreeNode nodeTrue;
    public DecisionTreeNode nodeFalse;

}
