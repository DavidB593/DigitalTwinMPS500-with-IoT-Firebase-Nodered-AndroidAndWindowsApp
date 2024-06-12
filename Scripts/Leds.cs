using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using System.Threading;


public class Leds : MonoBehaviour
{
    DatabaseReference reference;

    public GameObject LED1on;
    public GameObject LED2on;
    public GameObject LED3on;
    public GameObject LED4on;
    public GameObject LED5on;
    public GameObject LED6on;
    public GameObject LED7on;
    public GameObject LED1off;
    public GameObject LED2off;
    public GameObject LED3off;
    public GameObject LED4off;
    public GameObject LED5off;
    public GameObject LED6off;
    public GameObject LED7off;
    public GameObject MPSon;
    public GameObject MPSoff;
    public GameObject MPSontxt;
    public GameObject MPSofftxt;
    short var1 = 0;
    short var2 = 0;
    short var3 = 0;
    short var4 = 0;
    short var5 = 0;
    short var6 = 0;
    short var7 = 0;
    short var8 = 0;
    string ED1val="False";
    string EV2val="False";
    string EP3val="False";
    string ECC4val="False";
    string ECL7val="False";
    string MPS="False";

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        //Senial MPS
        reference.Child("DATOS").Child("Outputs").GetValueAsync().ContinueWith(task =>         // Recupera datos de Firebase
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                               
                MPS = snapshot.Child("MPS").Value.ToString();
            }

        });

        //Seniales others
        reference.Child("DATOS").GetValueAsync().ContinueWith(task =>         // Recupera datos de Firebase
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                ED1val = snapshot.Child("OutputsED1EV2").Child("signal_cilindro").Value.ToString();
                EV2val = ED1val;
                EP3val = snapshot.Child("OutputsEP3").Child("llega_pieza").Value.ToString();
                ECC4val = snapshot.Child("OutputsECC4").Child("llega_pieza").Value.ToString();
                ECL7val = snapshot.Child("OutputsECLA7").Child("llega_pieza").Value.ToString();
            }

        });




        //1
        if (ED1val == "True" && (var1 == 1 || var1 == 0))
        {
            LED1on.SetActive(true);
            LED1off.SetActive(false);
            var1 = 2;            
        }

        if (ED1val == "False" && (var1 == 2 || var1 == 0))
        {
            Thread.Sleep(4000);
            LED1on.SetActive(false);
            LED1off.SetActive(true);
            var1 = 1;            
        }

        //2
        if (EV2val == "True" && (var2 == 1 || var2 == 0))
        {
            LED2on.SetActive(true);
            LED2off.SetActive(false);
            var2 = 2;
        }

        if (EV2val == "False" && (var2 == 2 || var2 == 0))
        {
            Thread.Sleep(4000);
            LED2on.SetActive(false);
            LED2off.SetActive(true);
            var2 = 1;
        }


        //3
        if (EP3val == "True" && (var3 == 1 || var3 == 0))
        {
            LED3on.SetActive(true);
            LED3off.SetActive(false);
            var3 = 2;
        }

        if (EP3val == "False" && (var3 == 2 || var3 == 0))
        {
            Thread.Sleep(4000);
            LED3on.SetActive(false);
            LED3off.SetActive(true);
            var3 = 1;
        }


        //4
        if (ECC4val == "True" && (var4 == 1 || var4 == 0))
        {
            LED4on.SetActive(true);
            LED4off.SetActive(false);
            var4 = 2;
        }

        if (ECC4val == "False" && (var4 == 2 || var4 == 0))
        {
            Thread.Sleep(4000);
            LED4on.SetActive(false);
            LED4off.SetActive(true);
            var4 = 1;
        }


        

        //7
        if (ECL7val == "True" && (var7 == 1 || var7 == 0))
        {
            LED7on.SetActive(true);
            LED7off.SetActive(false);
            var7 = 2;
        }

        if (ECL7val == "False" && (var7 == 2 || var7 == 0))
        {
            Thread.Sleep(4000);
            LED7on.SetActive(false);
            LED7off.SetActive(true);
            var7 = 1;
        }



        //8
        if (MPS == "True" && (var8 == 1 || var8 == 0))
        {
            MPSon.SetActive(true);
            MPSoff.SetActive(false);
            MPSontxt.SetActive(true);
            MPSofftxt.SetActive(false);
            var8 = 2;
        }

        if (MPS == "False" && (var8 == 2 || var8 == 0))
        {
            MPSon.SetActive(false);
            MPSoff.SetActive(true);
            MPSontxt.SetActive(false);
            MPSofftxt.SetActive(true);
            var8 = 1;
        }



    }
}
