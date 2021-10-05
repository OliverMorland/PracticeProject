using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using TMPro;

public class RandomKataGeneratorTestSuite
{

    string kataGeneratorObjectName = "RandomKataGeneratorManager";
    string kataDisplayerObjectName = "KataDisplayer";


    [UnityTest]
    public IEnumerator WhenMouseClicekdKataDisplayShowsNewText()
    {
        //construct
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(0.5f);
        GameObject kataGeneratorManagerGO = GameObject.Find(kataGeneratorObjectName);
        GameObject kataDisplayerGO = GameObject.Find(kataDisplayerObjectName);

        if (kataGeneratorManagerGO == null)
        {
            Debug.Log("There is no Kata Generator Manager");
        }    

        //action
        RandomKataGeneratorManager kataGeneratorManager = kataGeneratorManagerGO.GetComponent<RandomKataGeneratorManager>();
        string kataTextBefore = kataDisplayerGO.GetComponentInChildren<TextMeshPro>().text;
        kataGeneratorManager.RandomlySelectKata();
        yield return new WaitForSeconds(0.1f);
        string kataTextAfter = kataDisplayerGO.GetComponentInChildren<TextMeshPro>().text;

        //assert
        Assert.That(kataTextAfter != kataTextBefore);
    }
}
