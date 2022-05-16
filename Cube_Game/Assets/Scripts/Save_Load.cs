using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
public class Save_Load : MonoBehaviour
{
     public static Save_Load instance;
    public bool hasLoaded;

    public void Awake()
    {
        instance = this;
        Load();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    public SaveData activeSave;
    
    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveLevelName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Save");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if(System.IO.File.Exists(dataPath + "/" + activeSave.saveLevelName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveLevelName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasLoaded = true;
        }
    }
    [System.Serializable]
    public class SaveData
    {
        public string saveLevelName;

        public float saveTime;

        public int savePoints;

        public double saveSeed;
    }
}
