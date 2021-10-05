using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomKataGeneratorManager : MonoBehaviour
{
    public string[] katas;
    public float transitionTime;
    public TextMeshPro kataText;
    public float cycleTimePeriod = 0.5f;
    float cycleStartTime = 0;
    float elapsedTime;
    Vector3 kataDisplayerStartPosition;

    private void Start()
    {
        RandomlySelectKata();
        kataDisplayerStartPosition = GetKataDisplayer().transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cycleStartTime = Time.time;
            RandomlySelectKata();
        }

        updateKataDisplayerPosition();
    }

    public void RandomlySelectKata()
    {
        kataText.text = getRandomKata();
    }

    string getRandomKata()
    {
        if (katas.Length < 1)
        {
            Debug.LogWarning("I have no katas");
            return null;
        }
        int rand = Random.Range(0, katas.Length);
        Debug.Log(rand);
        return katas[rand];
    }

    void updateKataDisplayerPosition()
    {
        GameObject kataDisplayer = GetKataDisplayer();
        elapsedTime = Mathf.Clamp(Time.time - cycleStartTime, 0, cycleTimePeriod / 2);
        float offset = Mathf.Sin((elapsedTime / cycleTimePeriod) * 2 * Mathf.PI);
        kataDisplayer.transform.position = kataDisplayerStartPosition + new Vector3(0, 0, offset);
    }

    bool isKataDisplayerInScene()
    {
        GameObject kataDisplayer = GetKataDisplayer();
        if (!kataDisplayer)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    GameObject GetKataDisplayer()
    {
        return GameObject.Find("KataDisplayer");
    }

}
