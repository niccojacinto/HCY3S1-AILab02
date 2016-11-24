using UnityEngine;
using System.Collections;
using System.Reflection;

public class DecisionTreeNode : MonoBehaviour {

    public string nodeName = "";

    void Start()
    {
    }

    public virtual DecisionTreeNode MakeDecision()
    {
        return null;
    }
}
