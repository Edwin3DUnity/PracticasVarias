using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CambioColor : MonoBehaviour
{
    private SpriteRenderer imagen;
    private List<Color> colores;
    private int colorIndex = 0;

    void Start()
    {
        imagen = GetComponent<SpriteRenderer>();

        colores = new List<Color>();

        for (int i = 0; i < 100; i++)
        {
            colores.Add(Random.ColorHSV());
        }
        
        
        
        
        StartCoroutine(CambioColorPez());
    }

    void Update()
    {
    }

    IEnumerator CambioColorPez()
    {
        while (true)
        {
            imagen.color = colores[colorIndex];
            yield return new WaitForSeconds(1);
            colorIndex = (colorIndex + 1) % colores.Count;
        }
    }
}