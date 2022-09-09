using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour, IPlaneteryObject
{
    [SerializeField] private float m_mass;
    [SerializeField] private float m_radius;
    [SerializeField] private PlanetType m_planetType;

    private PlaneterySystemFactory m_factory;

    public float Mass
    {
        get => m_mass;
        set 
        {
            m_mass = value;

            if (value >= 0 && value <= 0.00001) 
            {
                m_planetType = PlanetType.Asteroidan;
            }
            else if(value >= 0.00001 && value <= 0.1) 
            {
                m_planetType = PlanetType.Mercurian;
            }
            else if(value >= 0.1 && value <= 0.5) 
            {
                m_planetType = PlanetType.Subterran;
            }
            else if(value >= 0.5 && value <= 2) 
            {
                m_planetType = PlanetType.Terran;
            }
            else if(value >= 2 && value <= 10) 
            {
                m_planetType = PlanetType.Supperterran;
            }
            else if(value >= 10 && value <= 50) 
            {
                m_planetType = PlanetType.Neptunian;
            }
            else if(value >= 50 && value <= 5000) 
            {
                m_planetType = PlanetType.Jovian;
            }
        }
    }
    public float Radius
    {
        get => m_radius;
        set 
        {
            m_radius = value;

            if (m_planetType == PlanetType.Asteroidan)
                m_radius = Random.Range(0f, 0.03f);
            else if (m_planetType == PlanetType.Mercurian)
                m_radius = Random.Range(0.03f, 0.7f);
            else if (m_planetType == PlanetType.Subterran)
                m_radius = Random.Range(0.5f, 1.2f);
            else if (m_planetType == PlanetType.Terran)
                m_radius = Random.Range(0.8f, 1.9f);
            else if (m_planetType == PlanetType.Supperterran)
                m_radius = Random.Range(1.3f, 3.3f);
            else if (m_planetType == PlanetType.Neptunian)
                m_radius = Random.Range(2.1f, 5.7f);
            else if (m_planetType == PlanetType.Jovian)
                m_radius = Random.Range(3.5f, 27f);
        }
    }
    public PlanetType planetType
    {
        get => m_planetType;
        set => m_planetType = value;
    }

    private void Awake()
    {
        m_factory = FindObjectOfType<PlaneterySystemFactory>();
    }

    private void Start()
    {
        Mass = Random.Range(0.0f, 5000f);
        Radius = Random.Range(0f, 27f);
        transform.localScale = new Vector3(m_radius / 5, m_radius / 5, 1.0f);
    }
}
