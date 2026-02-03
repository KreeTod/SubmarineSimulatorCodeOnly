using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Crew
{
    Comandor,
    Driver,
    Gunner,
    Reloader,
    Radio
}
public class CrewControls : MonoBehaviour
{
    public Crew CurrentCrewPosition = Crew.Comandor;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CurrentCrewPosition = Crew.Driver;
        }
    }
    public void ChangeView(Crew value)
    {
        CurrentCrewPosition = value;
    }
}
