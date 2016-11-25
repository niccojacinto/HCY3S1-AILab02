using UnityEngine;
using System.Collections;

public class EnergyPill : Pickup {

    public static int numEnergyPills = 0;
    private float giveAmount = 10.0f;

    protected override void Update() {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }

    public override void OnPickup(Character character) {
        base.OnPickup(character);
        character.AddEnergy(giveAmount);
        numEnergyPills--;
        Destroy(gameObject);
    }
}
