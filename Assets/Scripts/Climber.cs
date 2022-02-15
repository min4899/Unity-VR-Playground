using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    // static to allow 'climbingHand' variable to be accessible in other scripts without referencing.
    public static XRController climbingHand;

    private CharacterController character;
    private ContinuousMovement continuousMovement;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ContinuousMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(climbingHand) {
            continuousMovement.enabled = false;
            Climb();
        }
        else {
            continuousMovement.enabled = true;
        }
    }

    // CLimbing Computations
    void Climb() 
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime); 
    }
}
