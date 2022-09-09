using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneteryObject
{
    float Mass { get; set; }
    float Radius { get; set; }
    PlanetType planetType { get; set; }
}
