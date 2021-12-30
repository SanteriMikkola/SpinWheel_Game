using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    private int RandomValue;
    private float timeInterval;
    private int finalAngle;

    [SerializeField]
    private int int1;
    [SerializeField]
    private int int2;

    [SerializeField]
    private float float1;
    [SerializeField]
    private float float2;

    public void StartSpinning()
    {
        StartCoroutine("Spin");
    }

    private IEnumerator Spin()
    {
        RandomValue = Random.Range(int1, int2); //50, 55
        timeInterval = 0.04f;

        for (int i = 0; i < RandomValue; i++)
        {
            transform.Rotate(0, 0, float1); //-12.25
            if (i > Mathf.RoundToInt(RandomValue * 0.25f))
            {
                timeInterval = 0.055f;
            }
            if (i > Mathf.RoundToInt(RandomValue * 0.425f))
            {
                timeInterval = 0.08f;
            }
            yield return new WaitForSeconds(timeInterval);
        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % float2 != 0)   //-25
        {
            transform.Rotate(0, 0, float1); //-12.25
        }
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
    }
}
