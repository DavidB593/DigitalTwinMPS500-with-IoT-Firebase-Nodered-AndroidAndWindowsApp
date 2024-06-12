using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onoffslider : MonoBehaviour
{
    Text onoff;
    // Start is called before the first frame update
    void Start()
    {
        onoff = GetComponent<Text>();
    }

    // Update is called once per frame
    public void DTwinonoff(float value)
    {
        onoff.text = Mathf.RoundToInt(value) + "";  //para poner alguna unidad            numpiezas.text = Mathf.RoundToInt(value * 100 + "%"); 
    }
}