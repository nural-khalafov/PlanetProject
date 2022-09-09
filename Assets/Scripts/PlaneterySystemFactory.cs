using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneterySystemFactory : MonoBehaviour, IPlaneterySystemFactory
{
    public GameObject PlanetPrefab;
    public Planet Planet;
    public PlanetMovement PlanetMovement;

    public int PlanetCount;

    public void Create(float mass)
    {
        var newPlanet = Instantiate(PlanetPrefab, Vector2.zero, Quaternion.identity);
    }

    public void Awake()
    {
        PlanetMovement = Planet.GetComponent<PlanetMovement>();
    }

    private void Start()
    {
        for(int i = 1; i <= PlanetCount; i++) 
        {
            Create(Planet.Mass);
            PlanetMovement.RotationRadius = i;
        }
    }
}
