using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchimedesForce : MonoBehaviour
{
    private double CalculateForce(float V)
    {
        double F_a = /*r*/(float)Constants.WaterRho * /*g*/Physics.gravity.magnitude * /*V from liter to m^3*/(V * 0.001);
        return F_a;
    }
}
