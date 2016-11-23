using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour {

    protected float rotationSpeed = 180.0f;

	protected virtual void Start () {
        GetComponent<Collider>().isTrigger = true;
	}
	
	
	protected virtual void Update () {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}

    public virtual void OnPickup(Character character) {
        Level.allPickups.Remove(this);
    }
}
