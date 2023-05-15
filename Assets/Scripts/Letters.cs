using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    string frase = "Una vida fue quitada, ahora varias deben ser cobradas hasta la piedra ser recolectada; torsos y piernas, no pueden ser dejadas.";
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        foreach(char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.09f);
        }
        
    }
    
}
