using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class OrbitRenderer : MonoBehaviour
{
    private LineRenderer m_orbitRenderer;
    private Color m_planetColor;

    private PlanetMovement m_planetMovement;

    private void Awake()
    {
        m_orbitRenderer = GetComponent<LineRenderer>();
        m_planetColor = GetComponentInParent<SpriteRenderer>().color;
        m_planetMovement = GetComponentInParent<PlanetMovement>();
    }

    private void Start()
    {
        DrawOrbit(100, m_planetMovement.RotationRadius);
        SetSingleColor(this.GetComponent<LineRenderer>(), m_planetColor);
    }

    private void DrawOrbit(int steps, float radius) 
    {
        m_orbitRenderer.positionCount = steps;

        for(int currentStep = 0; currentStep < steps; currentStep++) 
        {
            float circumferenceProgress = (float)currentStep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);

            m_orbitRenderer.SetPosition(currentStep, currentPosition);
        }
    }

    private void SetSingleColor(LineRenderer lineRenderer, Color color) 
    {
        Gradient tempGradient = new Gradient();

        GradientColorKey[] tempColorKeys = new GradientColorKey[2];
        tempColorKeys[0] = new GradientColorKey(color, 0);
        tempColorKeys[1] = new GradientColorKey(color, 1);

        tempGradient.colorKeys = tempColorKeys;

        lineRenderer.colorGradient = tempGradient;
    }
}
