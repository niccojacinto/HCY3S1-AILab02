using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class AIController : Character {

    public DecisionTree decisionTree;

	protected override void Start () {
        base.Start();
    }
	
	protected override void Update () {
        base.Update();
	}
} 
