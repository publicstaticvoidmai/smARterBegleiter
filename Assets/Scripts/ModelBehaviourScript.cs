using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBehaviourScript : DefaultTrackableEventHandler
{

    private float rate = 2;
    private float normalizedRange = 0.9f;



    private void Update()
    {
        //virus floating
        transform.Rotate(30, 0, 0);
        transform.position += Vector3.up * Mathf.Cos(Time.time * rate) * normalizedRange * 2;

    }

    


}
