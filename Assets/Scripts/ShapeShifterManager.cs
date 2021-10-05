using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShifterManager : MonoBehaviour
{
    public GameObject m_ShapeShifter;
    public Mesh[] m_shapeMeshes;
    public int m_index;

    public void ToggleButtonPressed()
    {
        IncrementIndex();
        ToggleShape();
    }

    public void RedButtonPressed()
    {

    }

    public void GreenButtonPressed()
    {

    }

    public void IncrementIndex()
    {
        int shapesCount = m_shapeMeshes.Length;
        if (m_index == shapesCount-1)
        { 
            m_index = 0;
        }
        else
        {
            m_index++;
        }
    }

    public void UpdateShapeName()
    {

    }

    void ToggleShape()
    {
        m_ShapeShifter.GetComponent<MeshFilter>().mesh = m_shapeMeshes[m_index];
    }

    public void ChangeColorRed()
    {

    }

    public void ChangeColorGreen()
    {

    }


}
