using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxLibrary : MonoBehaviour {

    public SoundGroup[] soundGroups;

    Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]>();

    void Awake() {
        foreach (SoundGroup soundGroup in soundGroups) {
            groupDictionary.Add (soundGroup.groupID, soundGroup.group);
        }
    }

    public AudioClip GetClipFromName(string name) {
        if (groupDictionary.ContainsKey (name)) {
            AudioClip[] sounds = groupDictionary [name];
            return sounds [Random.Range (0, sounds.Length)];
        }
        return null;
    }

    // Class to store the sound groups
    [System.Serializable]
    public class SoundGroup 
    {
        // Name of the group
        public string groupID;
        // Array of AudioClip to use the sfx
        public AudioClip[] group;
    }
}
