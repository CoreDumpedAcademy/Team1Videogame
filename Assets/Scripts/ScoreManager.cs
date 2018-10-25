using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private const string fileName = "s.bin";

    public Text Score;
    public float timer;
    public int score;
    private bool isSaved;

    public Dictionary<int, KeyValuePair<int, string>> playerScores;

	// Use this for initialization
	void Start () {
        Init();
        score = 0;
        RefreshScore();
        isSaved = false;
    }

    void Init()
    {
        playerScores = new Dictionary<int, KeyValuePair<int, string>>();

        LoadScoreBoard();
    }
    
    public void SetScore(string username)
    {
        if (!isSaved)
        {
            isSaved = true;
            AddScoreInOrder(username);
            SaveScoreBoard();
        }
    }

    private void AddScoreInOrder(string playerName)
    {
        if (playerScores.Count > 0) {
            orderScoreBoard(playerName);
        }
        else
        {
            Debug.Log("Saved file not found");
            AddScore(1, score, playerName);
        }
    }

    private void orderScoreBoard(string playerName)
    {
        KeyValuePair<int, string> register;
        bool saved = false;
        int i = 1, partialScore = score, counter = playerScores.Count + 1;
        string partialPlayerName = playerName;

        while (i <= counter || !saved)
        {
            if (playerScores.TryGetValue(i, out register))
            {
                playerScores.Remove(i);

                if (register.Key < partialScore)
                {
                    AddScore(i, partialScore, partialPlayerName);
                    saved = true;
                    
                    partialScore = register.Key;
                    partialPlayerName = register.Value;
                }
                else
                {
                    AddScore(i, register.Key, register.Value);
                }
            }
            else
            {
                AddScore(i, partialScore, partialPlayerName);
                saved = true;
            }

            i++;
        }
    }

    private void AddScore(int position, int points, string playerName)
    {
        playerScores.Add(position, new KeyValuePair<int, string>(points, playerName));
    }

    private void SaveScoreBoard()
    {
        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);

        foreach(KeyValuePair<int, KeyValuePair<int, string>> registro in playerScores)
        {
            Debug.Log("Puntuacion " + registro.Key + " de " + registro.Value.Value + ": " + registro.Value.Key);

            bw.Write(registro.Key);
            bw.Write(registro.Value.Key);
            bw.Write(registro.Value.Value);
        }

        bw.Close();
        fs.Close();
    }

    private void LoadScoreBoard()
    {
        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);

        while(br.BaseStream.Position != br.BaseStream.Length)
        {
            AddScore(br.ReadInt32(), br.ReadInt32(), br.ReadString());
        }

        br.Close();
        fs.Close();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
	}

    private void FixedUpdate()
    {
        if (timer > 5f)
        {
            score += 100;
            RefreshScore();
            timer = 0;
        }
    }

    public void RefreshScore()
    {
        Score.text = "Score: " + score;
    }
}
