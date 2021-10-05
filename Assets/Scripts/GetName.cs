using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetName : MonoBehaviour
{
    public string [] m_namesArray = { "John", "Peter", "Sabrina", "Eleanor" };
    public string GetNameWithIndex(int index)
    {
        return m_namesArray[index];
    }
}
