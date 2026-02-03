using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Numerics; // for Complex numbers
using System.Linq;
/*
public class DisplayExperimental228 : MonoBehaviour
{

    [SerializeField] private Color[,] sonarData = new Color[128, 128];
    public Texture2D sonarTexture;
    [SerializeField] private double timer;




    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            UpdateSonarDisplay();
            timer = 0;
        }
    }

    public void UpdateSonarDisplay()
    {
        ClearSonarData();
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 128; y++)
            {
                float v = Random.Range(0f, 1f);
                sonarData[x, y] = Color.Lerp(Color.green, Color.black, v);
            }
        }
        UpdateTextureFromData();
    }

    private void ClearSonarData()
    {
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 128; y++)
            {
                sonarData[x, y] = Color.black;
            }
        }
    }

    private void UpdateTextureFromData()
    {
        // ѕреобразуем матрицу данных о текстуре в текстуру
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 128; y++)
            {
                sonarTexture.SetPixel(x, y, sonarData[x, y]);
            }
        }

        // ѕримен€ем изменени€ к текстуре
        sonarTexture.Apply();
    }
}//*/
