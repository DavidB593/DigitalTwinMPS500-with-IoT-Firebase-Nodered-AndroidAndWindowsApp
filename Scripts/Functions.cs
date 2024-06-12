using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;




public class Functions : MonoBehaviour
{
    DatabaseReference reference;

    [SerializeField] InputField usuario;
    [SerializeField] InputField contrasena;

    public GameObject habilitar;
    public GameObject habilitar2;
    public GameObject deshabilitar;
    public GameObject DTon;
    public GameObject DToff;    


    public Text Numpiezas;
    public Text OnOfftxt;


    string textValue1;
    public Text textElement1;
    string textValue2;
    public Text textElement2;
    string textValue3;
    public Text textElement3;
    


    string usuariotxt;
    string contrasenatxt;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }



    public void iniciarsesion()
    {
        reference.Child("USUARIOS").Child("Usuario1").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot snapshot = task.Result;

            usuariotxt = snapshot.Child("Usuario").Value.ToString();
            contrasenatxt = snapshot.Child("Contrasena").Value.ToString();
        });

        if (usuario.text == usuariotxt && contrasena.text == contrasenatxt)
        {
            deshabilitar.SetActive(false);
            habilitar.SetActive(true);
            habilitar2.SetActive(true);
        }

    }



    public void DTwinonoff()
    {
        if (OnOfftxt.text == "0") OnOfftxt.text = "";
                

            Variable2 input = new Variable2();
        input.OnOff = OnOfftxt.text;
        string json = JsonUtility.ToJson(input);



        reference.Child("DATOS").Child("Input1").SetRawJsonValueAsync(json).ContinueWith(task =>
        {

        });
        
        if (OnOfftxt.text == "1")
        {
            DTon.SetActive(true);
            DToff.SetActive(false);
        }
        if (OnOfftxt.text == "")
        {
            DToff.SetActive(true);
            DTon.SetActive(false);
        }
        
    }




    public void NumerodePiezas()
    {
        Variables input = new Variables();
        input.Npiezas = Numpiezas.text;
        string json = JsonUtility.ToJson(input);

        reference.Child("DATOS").Child("Input2").SetRawJsonValueAsync(json).ContinueWith(task =>
        {

        });
                
    }


    public void Salir()
    {
        Application.Quit();
    }





    void Update()
    {
        
        reference.Child("DATOS").Child("Outputs").GetValueAsync().ContinueWith(task =>         // Recupera datos de Firebase
        {            
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                
                textValue1 = snapshot.Child("Projas").Value.ToString();
                textValue2 = snapshot.Child("Pnegras").Value.ToString();
                textValue3 = snapshot.Child("Pmet").Value.ToString();
                
            }

        });

        textElement1.text = textValue1;
        textElement2.text = textValue2;
        textElement3.text = textValue3;

              

    }

   

}

