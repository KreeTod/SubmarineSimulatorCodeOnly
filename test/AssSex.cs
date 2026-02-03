using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssSex : MonoBehaviour
{
    private float[] samples;
    private Complex[] complexSamples;
    private float[] window;
    [SerializeField] private int sampleSize = 512; // Размер выборки, должен быть степенью двойки
    [SerializeField] private int textureSize = 128; // Размер текстуры
    [SerializeField] private Texture2D _spectrogramTexture;
    [SerializeField] private Material _spectrogramMaterial;
    [SerializeField] private GameObject _spectrogramObj;
    private Color[] colors;
    private List<float[]> spectrumHistory;

    void Start()
    {
        samples = new float[sampleSize];
        complexSamples = new Complex[sampleSize];
        colors = new Color[textureSize * textureSize];
        spectrumHistory = new List<float[]>();
        window = new float[sampleSize];
        ApplyHannWindow(window, sampleSize);

        _spectrogramTexture = new Texture2D(128, 128);
        _spectrogramMaterial = new Material(Shader.Find("Standard"));
        _spectrogramMaterial.mainTexture = _spectrogramTexture;
        _spectrogramMaterial.SetTexture("_EmissionMap", _spectrogramTexture);
        _spectrogramMaterial.EnableKeyword("_EMISSION");
        _spectrogramMaterial.SetColor("_EmissionColor", Color.white);
        _spectrogramObj.GetComponent<Renderer>().material = _spectrogramMaterial;

        // Инициализируем текстуру черным цветом
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }
        _spectrogramTexture.SetPixels(colors);
        _spectrogramTexture.Apply();
    }

    void FixedUpdate()
    {
        // Получаем аудиоданные из AudioListener
        AudioListener.GetOutputData(samples, 0);

        // Применяем оконную функцию
        for (int i = 0; i < sampleSize; i++)
        {
            samples[i] *= window[i];
        }

        // Преобразуем аудиоданные в комплексные числа
        for (int i = 0; i < sampleSize; i++)
        {
            complexSamples[i] = new Complex(samples[i], 0);
        }

        // Выполняем БПФ
        FFT.ComputeFFT(complexSamples);

        // Сохраняем амплитуды
        float[] magnitudes = new float[textureSize];
        for (int i = 0; i < textureSize; i++)
        {
            magnitudes[i] = (float)complexSamples[i].Magnitude;
        }

        // Добавляем текущий спектр в историю
        spectrumHistory.Insert(0, magnitudes);
        if (spectrumHistory.Count > textureSize)
        {
            spectrumHistory.RemoveAt(spectrumHistory.Count - 1);
        }

        // Обновляем текстуру спектрограммы
        UpdateSpectrogramTexture();
    }

    void UpdateSpectrogramTexture()
    {
        for (int y = 0; y < textureSize; y++)
        {
            float[] spectrum = (y < spectrumHistory.Count) ? spectrumHistory[y] : null;
            for (int x = 0; x < textureSize; x++)
            {
                float value = (spectrum != null) ? Mathf.Clamp01(spectrum[x]) : 0.0f;
                colors[(textureSize - y - 1) * textureSize + x] = new Color(value, value, value);
            }
        }
        _spectrogramTexture.SetPixels(colors);
        _spectrogramTexture.Apply();
    }

    void ApplyHannWindow(float[] window, int size)
    {
        for (int i = 0; i < size; i++)
        {
            window[i] = 0.5f * (1 - Mathf.Cos(2 * Mathf.PI * i / (size - 1)));
        }
    }
}