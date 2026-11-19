using UnityEngine;

public class PetHitBox : MonoBehaviour
{
    public string triggerZoneName; // e.g., "Head", "Feet", or "AggroRadius"
    private Pet parentScript;

    private void Awake()
    {
        parentScript = GetComponentInParent<Pet>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        print("hit");
        if (other.tag == "toy")
        parentScript.HanddleVission( other);
       
    }
}
