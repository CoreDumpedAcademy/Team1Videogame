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

    public Dictionary<int, KeyValuePair<int, string>> playerScores;

	// Use this for initialization
	void Start () {
        Init();
        score = 0;
        RefreshScore();
    }

    void Init()
    {
        playerScores = new Dictionary<int, KeyValuePair<int, string>>();

        LoadScoreBoard();
    }
    
    public void SetScore(int value, string username)
    {
        AddScoreInOrder(value, username);

        SaveScoreBoard();
    }

    private void AddScoreInOrder(int score, string playerName)
    {
        KeyValuePair<int, string> register;

        for (int i = playerScores.Count; i > 0; i--)
        {
            if(playerScores.TryGetValue(i, out register))
            {
                if(register.Key < score)
                {

                }
            }
        }
    }

    private void AddScore(int position, int score, string playerName)
    {
        playerScores.Add(position, new KeyValuePair<int, string>(score, playerName));
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
