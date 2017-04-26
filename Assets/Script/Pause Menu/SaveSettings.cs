using System;
using System.IO;
using UnityEngine;

    [System.Serializable]
    public class SaveSettings
    {
        // WILL BE USE FOR CHECKPOINT/QUICKSAVE IF NEEDED


        public string fileName = "GameSettings.json";
        // The string that will be saved.
        static string jsonString;

        /// Create the JSON object needed to save settings.
        public static object createJSONOBJ(string jsonString)
        {
            return JsonUtility.FromJson<SaveSettings>(jsonString);
        }

        /// Read the game settings from the file
        public void LoadGameSettings(String readString)
        {
            try
            {
                //SaveSettings read = (SaveSettings)createJSONOBJ(readString);
	        }
            catch (FileNotFoundException)
            {
                Debug.Log("Game settings not found in: " + Application.persistentDataPath + "/" + fileName);
            }
        }

        /// Get the quality/music settings before saving 
        public void SaveGameSettings()
        {
            if (File.Exists(Application.persistentDataPath + "/" + fileName))
            {
                File.Delete(Application.persistentDataPath + "/" + fileName);
            }
   			jsonString = JsonUtility.ToJson(this);
            Debug.Log(jsonString);
            File.WriteAllText(Application.persistentDataPath + "/" + fileName, jsonString);
        }
	}