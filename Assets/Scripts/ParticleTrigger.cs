using UnityEngine;
using UnityEngine.Events;

public class ParticleTrigger : MonoBehaviour
{
    

    public Rigidbody triggerBody;
    public UnityEvent onTriggerEnter;


    void OnTriggerEnter(Collider other)
    {
        //do not trigger if there's no trigger target object
        if (triggerBody == null) return;

        //only trigger if the triggerBody matches
        var hitRb = other.attachedRigidbody;
        if (hitRb == triggerBody)
        {
            onTriggerEnter.Invoke();
        }

        
    }

}
