using UnityEngine;
using System.Collections;

public class HealthPack : Pickup {

    public static int numHealthPacks = 0;
    private float giveAmount = 10.0f;

    public override void OnPickup(Character character) {
        base.OnPickup(character);

        character.AddHealth(giveAmount);
        numHealthPacks--;
        Destroy(gameObject);

    }
}
