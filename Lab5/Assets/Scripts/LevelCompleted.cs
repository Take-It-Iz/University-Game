using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.CompareTag("Player")) 
		{
			SaveChanges(other);
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void SaveChanges(Collider2D other)
    {	
		// Save using PlayrPrefs	
        PlayerPrefs.SetString("PlayerName", other.name);
		PlayerPrefs.SetString("PlayerTag", other.tag);		
		PlayerPrefs.Save();

		// Save using persistent data		
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file;
		PlayerData playerData = new PlayerData();

		if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
		{
			file = File.OpenWrite(Application.persistentDataPath + "/gameInfo.dat");			
		}    	
		else
		{
			file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
		}		

		playerData.playerName = other.name;
		playerData.playerTag = other.tag;

		binaryFormatter.Serialize(file, other);
    	file.Close();
    }

	[Serializable]
    public class PlayerData 
    {
        public string playerName;
        public string playerTag;
    }
}