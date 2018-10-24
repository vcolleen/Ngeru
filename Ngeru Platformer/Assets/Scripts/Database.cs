using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Database : MonoBehaviour {

    public static PlayerInfo player;

	string SAVE_FILE = "/SAVEGAME";
	string FILE_EXTENSION = ".BIN"; //You can change this to what ever you want so that the player can't edit their save data.

    public string _playername;
    public int _level;

    private void Awake()
    {
        player = new PlayerInfo();
    }

    public void SaveData()
	{
		Stream stream = File.Open (Application.dataPath + SAVE_FILE + FILE_EXTENSION, FileMode.OpenOrCreate);
		BinaryFormatter bf = new BinaryFormatter ();

        player.PlayerName = _playername; //We have these here so we can see them in the inspector.
        player.level = _level;

        bf.Serialize(stream, player);
        stream.Close();
	}

    public void LoadData()
    {
        Stream stream = File.Open(Application.dataPath + SAVE_FILE + FILE_EXTENSION, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();

        player = (PlayerInfo)bf.Deserialize(stream);
        stream.Close();

        _playername = player.PlayerName;
        _level = player.level;
    }

}
