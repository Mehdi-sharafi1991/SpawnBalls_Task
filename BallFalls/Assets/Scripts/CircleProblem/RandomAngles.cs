using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAngles : MonoBehaviour
{
    float[] RandomSelectedAngles;
    float minDelat = 10.0f;
    public int angleNums;
    // Start is called before the first frame update
    void Start()
    {
        float[] SelectRandomAngle = RandomAngle(angleNums);
        
    }

    // Update is called once per frame
   

    public float[] RandomAngle(int NumbeOfAngles)
    {
        if (NumbeOfAngles > 36 || NumbeOfAngles < 2)
        {
            Debug.LogError("input value must be between 2 and 36");
            return null;
        }
           
        RandomSelectedAngles = new float[NumbeOfAngles];
        RandomSelectedAngles[0] = Random.Range(0.0f, 360.0f);
        float LowerLimit = RandomSelectedAngles[0] - minDelat;
        for (int i = 1; i < NumbeOfAngles; i++)
        {
            float maxAllowableValue = (360 + LowerLimit) - (NumbeOfAngles - i - 1) * minDelat;
            float maxDelta = maxAllowableValue - RandomSelectedAngles[i - 1];
            RandomSelectedAngles[i] = RandomSelectedAngles[i - 1] + Random.Range(minDelat, maxDelta);
            
        }
        for (int i = 0; i < NumbeOfAngles; i++)
        {
            if (RandomSelectedAngles[i] > 360)
                RandomSelectedAngles[i] -= 360 ;
            if (RandomSelectedAngles[i] < 0)
                RandomSelectedAngles[i] += 360;
            
        }
        return RandomSelectedAngles;


    }
}
