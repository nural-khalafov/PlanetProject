using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] private Transform m_rotationCenter;
    public SpriteRenderer PlanetRenderer;

    public float RotationRadius;
    [SerializeField] private float m_angularSpeed;

    private float m_posX = 0f;
    private float m_posY = 0f;
    private float m_angle = 0f;

    private void Awake()
    {
        PlanetRenderer = GetComponent<SpriteRenderer>();
        m_rotationCenter = GameObject.Find("Center").transform;
    }

    private void Start()
    {
        RotationRadius += 1;
        m_angularSpeed = 1 / RotationRadius;
        PlanetRenderer.color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            255);
    }

    private void Update()
    {
        m_posX = m_rotationCenter.position.x + Mathf.Cos(m_angle) * RotationRadius;
        m_posY = m_rotationCenter.position.y + Mathf.Sin(m_angle) * RotationRadius;

        transform.position = new Vector2(m_posX, m_posY);

        m_angle = m_angle + Time.deltaTime * m_angularSpeed;

        if(m_angle >= 360f) 
        {
            m_angle = 0f;
        }

    }
}
