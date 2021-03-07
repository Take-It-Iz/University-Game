using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
	[SerializeField] private PlayerData playerData = new PlayerData();
	string dataSave;
    private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.CompareTag("Player")) 
		{
			SaveToJson(other);
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void SaveToJson(Collider2D other)
    {		
        playerData.playerName = other.name;
        playerData.playerTag = other.tag;
        dataSave = JsonUtility.ToJson(playerData);

		System.IO.File.WriteAllText("Assets/Resources/GameJSONData/SaveData.json", dataSave); 
    }

	[Serializable]
    public class PlayerData 
    {
        public string playerName;
        public string playerTag;
    }
}