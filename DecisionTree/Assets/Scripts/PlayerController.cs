using UnityEngine;
using System.Collections;

public class PlayerController : Character {

	protected override void Update () {
        base.Update();
        HandleInput();
	}

    private void HandleInput() {
        transform.Translate(Vector3.forward * linearSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(Vector3.up * angularSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {
            AttackForward();
        }
    }
}
