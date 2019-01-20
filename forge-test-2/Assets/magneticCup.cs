
using System;
using System.Collections.Generic;
using UnityEngine;
 
 
internal class magneticCup : MonoBehaviour
{
    [SerializeField]
    Rigidbody MarbleRigidBody;

    float MaxDistance = 4f; // Maximum range at which the marble will start being pulled to the cup
    float MaxStrength = 2f; // Strength with which the marble will be pulled when it is right next to the cup (reduces with distance)

    void Update()
    {
        Update_Magnetism();
        //Update_CupDirection();
    }

    void Update_Magnetism()
    {
        float Distance = Vector3.Distance(MarbleRigidBody.transform.position, this.transform.position);

        if (Distance < MaxDistance) // Marble is in range of the magnet
        {
            float TDistance = Mathf.InverseLerp(MaxDistance, 0f, Distance); // Give a decimal representing how far between 0 distance and max distance.
            float strength = Mathf.Lerp(0f, MaxStrength, TDistance); // Use that decimal to work out how much strength the magnet should apple
            Vector3 DirectionToCup = (this.transform.position - MarbleRigidBody.transform.position).normalized; // Get the direction from the marble to the cup

            MarbleRigidBody.AddForce(DirectionToCup * strength, ForceMode.Force);// apply force to the marble

        }
    }

    void Update_CupDirection()
    {
        Vector3 DirectionToMarble = (MarbleRigidBody.transform.position - this.transform.position).normalized; // Direction from the cup to the marble
        this.transform.forward = DirectionToMarble; // Make the cap face that direction
    }

}