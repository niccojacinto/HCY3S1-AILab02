using UnityEngine;
using System.Collections;
using System.Reflection;

public class DecisionTreeNode : MonoBehaviour {

    public string nodeName = "null";

    public virtual DecisionTreeNode MakeDecision()
    {
        return null;
    }
}
