using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestSuite
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("UnitTesting");
    }

    [UnityTest]
    public IEnumerator IndexIncrementsWhenToggleButtonPressed()
    {
        ShapeShifterManager shapeShifterManager = GameObject.Find("ShapeShifterManager").GetComponent<ShapeShifterManager>();

        shapeShifterManager.m_index = 0;

        shapeShifterManager.ToggleButtonPressed();
        yield return new WaitForSeconds(0.1f);

        int expectedIndex = 1;

        Assert.That(shapeShifterManager.m_index, Is.EqualTo(expectedIndex));
    }

    [UnityTest]
    public IEnumerator IndexSetToZeroWhenToggleButtonPressedAndIndexIsEqualToArrayLengthMinusOne()
    {
        ShapeShifterManager shapeShifterManager = GameObject.Find("ShapeShifterManager").GetComponent<ShapeShifterManager>();
        Mesh[] shapeMeshes = shapeShifterManager.m_shapeMeshes;
        int shapesCount = shapeMeshes.Length;

        shapeShifterManager.m_index = shapesCount -1;

        shapeShifterManager.ToggleButtonPressed();
        yield return new WaitForSeconds(0.1f);

        int expectedIndex = 0;

        Assert.That(shapeShifterManager.m_index, Is.EqualTo(expectedIndex));
    }

    [UnityTest]
    public IEnumerator ShapeChangesWhenToggleButtonPressed()
    {
        ShapeShifterManager shapeShifterManager = GameObject.Find("ShapeShifterManager").GetComponent<ShapeShifterManager>();
        Mesh[] shapeMeshes = shapeShifterManager.m_shapeMeshes;

        shapeShifterManager.ToggleButtonPressed();
        yield return new WaitForSeconds(0.1f);

        int index = shapeShifterManager.m_index;
        Mesh expectedMesh = shapeMeshes[index];
        Mesh currentMesh = shapeShifterManager.m_ShapeShifter.GetComponent<MeshFilter>().mesh;

        Assert.That(currentMesh, Is.EqualTo(expectedMesh));
    }

    [TearDown]
    public void TearDown()
    {

    }
}
