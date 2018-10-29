using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FillUsernames : MonoBehaviour {
    private const string fileName = "s.bin";
    public RectTransform[] panel;
    public Text[] users;

    // Use this for initialization
    void Start()
    {
        panel = GetComponentsInChildren<RectTransform>();
        users = GetComponentsInChildren<Text>();

        fillUsers(loadUsers());
    }

    private string [] loadUsers()
    {
        int i = 0;
        
        string[] usuarios = loadUsersInFile(out i);

        for (; i < 10; i++)
        {
            usuarios[i] = "";
        }

        return usuarios;
    }

    private string[] loadUsersInFile(out int i)
    {
        string[] usuarios = new string[10];
        i = 0;
        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);
        while (br.BaseStream.Position != br.BaseStream.Length && i < 10)
        {
            br.ReadInt32();
            br.ReadInt32();
            usuarios[i] = br.ReadString();
            i++;
        }
        br.Close();
        fs.Close();
        return usuarios;
    }

    private void fillUsers(string[] usuarios)
    {
        int i = 0;

        foreach (RectTransform R in panel)
        {
            users = R.GetComponentsInChildren<Text>();

            foreach (Text t in users)
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
