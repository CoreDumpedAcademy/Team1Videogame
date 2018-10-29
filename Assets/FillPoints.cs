using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FillPoints : MonoBehaviour
{
    private const string fileName = "s.bin";
    public RectTransform[] panel;
    public Text[] points;

    // Use this for initialization
    void Start()
    {
        panel = GetComponentsInChildren<RectTransform>();
        points = GetComponentsInChildren<Text>();

        fillUsers(loadPoints());
    }

    private string[] loadPoints()
    {
        int i = 0;

        string[] puntos = loadPointsInFile(out i);

        for (; i < 10; i++)
        {
            puntos[i] = "";
        }

        return puntos;
    }

    private string[] loadPointsInFile(out int i)
    {
        string[] puntos = new string[10];
        i = 0;
        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);
        while (br.BaseStream.Position != br.BaseStream.Length && i < 10)
        {
            br.ReadInt32();
            puntos[i] = br.ReadInt32().ToString();
            br.ReadString();
            i++;
        }
        br.Close();
        fs.Close();
        return puntos;
    }

    private void fillUsers(string[] usuarios)
    {
        int i = 0;

        foreach (RectTransform R in panel)
        {
            points = R.GetComponentsInChildren<Text>();

            foreach (Text t in points)
            {
                if (i < 10)
                {
                    t.text = usuarios[i];
                    i++;
                }
            }
        }
    }
}
