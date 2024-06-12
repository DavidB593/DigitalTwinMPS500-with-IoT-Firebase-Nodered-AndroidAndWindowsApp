using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidertoString : MonoBehaviour
{
    Text numpiezas;
    // Start is called before the first frame update
    void Start()
    {
        numpiezas = GetComponent<Text>();
    }

    // Update is called once per frame
    public void NumerodePiezas(float value)
    {
        numpiezas.text = Mathf.RoundToInt(value) + "";  //para poner alguna unidad            numpiezas.text = Mathf.RoundToInt(value * 100 + "%"); 
    }
}
