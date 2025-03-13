using System.Collections.Generic;
using UnityEngine;

public class GravityE : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<GravityE> gravityObjectList;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (gravityObjectList == null )
        {
            gravityObjectList = new List<GravityE>();
        }

        gravityObjectList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (var objPlanets in gravityObjectList)
        {
            if (objPlanets != this)
            {
                Attract(objPlanets);
            }
        }
    }

    void Attract(GravityE other)
    {
        Rigidbody otherRb = other.rb;
        
        // find distance between 2 objects
        Vector3 direction = rb.position - otherRb.position;
        float distanceR = direction.magnitude;
        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distanceR, 2));

        Vector3 finalForce = forceMagnitude * direction.normalized;

        // addforce
        otherRb.AddForce(finalForce);
    }
}