using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class GetNameTest : MonoBehaviour
{
    [Test]
    public void GetNameWithIndex_Test()
    {
        GetName getName = new GetName();
        string[] names = getName.m_namesArray;
        int namesLength = getName.m_namesArray.Length;

        for (int i = 0; i < namesLength; i++)
        {
            string nameGotten = getName.GetNameWithIndex(i);
            string expectedName = names[i];
            Assert.That(nameGotten, Is.EqualTo(expectedName));
        }
    }
    
}
