using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class AIController : Character {

    protected DecisionTreeNode currentBehavior;
    public DecisionTree decisionTree;

	protected override void Start () {
        base.Start();
        StartCoroutine("Do");
    }
	
	protected override void Update () {
        base.Update();
        
        Debug.Log(currentBehavior.nodeName);
	}

    void Do()
    {
        currentBehavior = decisionTree.MakeDecision();
    }
} 
