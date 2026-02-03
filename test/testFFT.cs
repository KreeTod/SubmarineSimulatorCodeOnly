using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
/*
public class AudioSpectrogram : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private float[] samples;
    [SerializeField] private Complex[] complexSamples;
    [SerializeField] private int sampleSize = 512; // Размер выборки, должен быть степенью двойки
    [SerializeField] private int textureSize = 128; // Размер текстуры
    [SerializeField] private Texture2D spectrogramTexture;
    [SerializeField] private Color[] colors;
    [SerializeField] private List<float[]> spectrumHistory;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        samples = new float[sampleSize];
        complexSamples = new Complex[sampleSize];
        colors = new Color[textureSize * textureSize];
        spectrumHistory = new List<float[]>();

        // Инициализируем текстуру белым цветом
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }
        spectrogramTexture.SetPixels(colors);
        spectrogramTexture.Apply();
    }

    [SerializeField] private int gay = 0;
    [SerializeField] private double xxx = 0;
    void FixedUpdate()
    {
        xxx += Time.fixedDeltaTime;
        //if (xxx <= audioClip.length)
        //{
            // Считываем аудиоданные
            //audioSource.GetOutputData(samples, 0);
            audioClip.GetData(samples, 0);
            gay += 512;

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
        //}
    }

    void UpdateSpectrogramTexture()
    {
        for (int y = 0; y < textureSize; y++)
        {
            float[] spectrum = (y < spectrumHistory.Count) ? spectrumHistory[y] : null;
            for (int x = 0; x < textureSize; x++)
            {
                float value = (spectrum != null) ? Mathf.Clamp(spectrum[x], 0.0f, 1.0f) : 0.0f;
                colors[(textureSize - y - 1) * textureSize + x] = new Color(value, value, value);
            }
        }
        spectrogramTexture.SetPixels(colors);
        spectrogramTexture.Apply();
    }
}

// Структура для комплексных чисел
public struct Complex
{
    public double Real;
    public double Imaginary;

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);

    public static Complex operator +(Complex a, Complex b) =>
        new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);

    public static Complex operator -(Complex a, Complex b) =>
        new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);

    public static Complex operator *(Complex a, Complex b) =>
        new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);

    public static Complex Exp(Complex c) =>
        new Complex(Math.Exp(c.Real) * Math.Cos(c.Imaginary), Math.Exp(c.Real) * Math.Sin(c.Imaginary));
}

// Класс для выполнения БПФ
public static class FFT
{
    public static void ComputeFFT(Complex[] x)
    {
        int N = x.Length;

        if ((N & (N - 1)) != 0)
        {
            throw new ArgumentException("Длина массива должна быть степенью двойки.");
        }

        int logN = (int)Mathf.Log(N, 2);
        for (int i = 0; i < N; i++)
        {
            int reversed = BitReverse(i, logN);
            if (reversed > i)
            {
                Complex temp = x[i];
                x[i] = x[reversed];
                x[reversed] = temp;
            }
        }

        for (int s = 1; s <= logN; s++)
        {
            int m = 1 << s;
            Complex wm = Complex.Exp(new Complex(0, -2 * Mathf.PI / m));

            for (int k = 0; k < N; k += m)
            {
                //Complex w = Complex.One;
                Complex w = new Complex(1,0);
                for (int j = 0; j < m / 2; j++)
                {
                    Complex t = w * x[k + j + m / 2];
                    Complex u = x[k + j];
                    x[k + j] = u + t;
                    x[k + j + m / 2] = u - t;
                    w *= wm;
                }
            }
        }
    }

    private static int BitReverse(int n, int bits)
    {
        int reversedN = n;
        int count = bits - 1;

        n >>= 1;
        while (n > 0)
        {
            reversedN = (reversedN << 1) | (n & 1);
            count--;
            n >>= 1;
        }

        return ((reversedN << count) & ((1 << bits) - 1));
    }
}
//*/






public class AudioSpectrogram : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

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
        if (audioSource.isPlaying)
        {
            int currentSample = audioSource.timeSamples;

            if (currentSample + sampleSize <= audioClip.samples)
            {
                // Считываем аудиоданные
                audioClip.GetData(samples, currentSample);
                //AudioListener.GetOutputData(samples, 0);

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
        }
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

// Структура для комплексных чисел
public struct Complex
{
    public double Real;
    public double Imaginary;

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);

    public static Complex operator +(Complex a, Complex b) =>
        new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);

    public static Complex operator -(Complex a, Complex b) =>
        new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);

    public static Complex operator *(Complex a, Complex b) =>
        new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);

    public static Complex Exp(Complex c) =>
        new Complex(Math.Exp(c.Real) * Math.Cos(c.Imaginary), Math.Exp(c.Real) * Math.Sin(c.Imaginary));
}

// Класс для выполнения БПФ
public static class FFT
{
    public static void ComputeFFT(Complex[] x)
    {
        int N = x.Length;

        if ((N & (N - 1)) != 0)
        {
            throw new ArgumentException("Длина массива должна быть степенью двойки.");
        }

        int logN = (int)Mathf.Log(N, 2);
        for (int i = 0; i < N; i++)
        {
            int reversed = BitReverse(i, logN);
            if (reversed > i)
            {
                Complex temp = x[i];
                x[i] = x[reversed];
                x[reversed] = temp;
            }
        }

        for (int s = 1; s <= logN; s++)
        {
            int m = 1 << s;
            Complex wm = Complex.Exp(new Complex(0, -2 * Mathf.PI / m));

            for (int k = 0; k < N; k += m)
            {
                Complex w = new Complex(1, 0);
                for (int j = 0; j < m / 2; j++)
                {
                    Complex t = w * x[k + j + m / 2];
                    Complex u = x[k + j];
                    x[k + j] = u + t;
                    x[k + j + m / 2] = u - t;
                    w *= wm;
                }
            }
        }
    }

    private static int BitReverse(int n, int bits)
    {
        int reversedN = n;
        int count = bits - 1;

        n >>= 1;
        while (n > 0)
        {
            reversedN = (reversedN << 1) | (n & 1);
            count--;
            n >>= 1;
        }

        return ((reversedN << count) & ((1 << bits) - 1));
    }
}


