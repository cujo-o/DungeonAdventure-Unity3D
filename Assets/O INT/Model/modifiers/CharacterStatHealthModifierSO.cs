using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        PlayerHealth health = character.GetComponent<PlayerHealth>();
        if (health != null)
            Debug.Log("health");
            health.addhealth((int)val);
    }
}
