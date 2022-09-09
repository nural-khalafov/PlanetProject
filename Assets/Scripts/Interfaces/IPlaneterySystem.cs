using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneterySystem
{
    IEnumerable<IPlaneteryObject> GetPlanets();

    void Update(float deltaTime);
}
