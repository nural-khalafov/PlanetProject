using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneterySystem : MonoBehaviour, IPlaneterySystem
{

    private void Start()
    {
    }

    private void Update()
    {
        Update(Time.deltaTime);
    }

    public IEnumerable<IPlaneteryObject> GetPlanets()
    {
        return FindObjectsOfType<MonoBehaviour>().OfType<IPlaneteryObject>();
    }

    public void Update(float deltaTime)
    {
        GetPlanets();
    }
}
