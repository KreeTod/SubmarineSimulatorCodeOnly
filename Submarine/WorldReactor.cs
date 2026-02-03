using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldReactor : MonoBehaviour
{
    [SerializeField] private List<ReactorBlock> ReactorBlocks = new List<ReactorBlock>();
    [SerializeField] private float TotalPower;

    private void FixedUpdate()
    {
        TotalPower = 0;
        foreach (ReactorBlock block in ReactorBlocks)
        {
            TotalPower += block.OutputPower;
        }
    }
}
