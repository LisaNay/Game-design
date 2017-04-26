using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public enum AudioChannel {Master, Sfx, Music};

    // Other classes can get the values but not set them
    public float masterVolumePercent { get; private set; }
    public float sfxVolumePercent { get; private set; }
    public float musicVolumePercent { get; private set; }

    AudioSource sfx2DSource;
    // Play the main musics / volume can be ajusted / and can be Crossfade with another one
    AudioSource[] musicSources;
    int activeMusicSourceIndex;

    // Static public reference to the Audiomanager to use it somewhere else
    public static AudioManager instance;

    // Reference to the sfxLibrary
    SfxLibrary sfxLibrary;

    void Awake() {
        // Destroy duplicate of this instance
        if (instance != null) {
            Destroy (gameObject);
        } else {

            instance = this;
            DontDestroyOnLoad (gameObject);

            sfxLibrary = GetComponent<SfxLibrary> ();

            musicSources = new AudioSource[2];
            for (int i = 0; i < 2; i++) {
                GameObject newMusicSource = new GameObject ("Music source " + (i + 1));
                musicSources [i] = newMusicSource.AddComponent<AudioSource> ();
                musicSources [i].loop = true;
                newMusicSource.transform.parent = transform;
            }

            // Use to play sfx 
            GameObject newSfx2Dsource = new GameObject ("2D sfx source");
            sfx2DSource = newSfx2Dsource.AddComponent<AudioSource> ();
            newSfx2Dsource.transform.parent = transform;

            // Save Master / Music / Sfx value to ...vol (if it's exist) or 1 as default
            masterVolumePercent = PlayerPrefs.GetFloat ("master vol", 1);
            sfxVolumePercent = PlayerPrefs.GetFloat ("sfx vol", 1);
            musicVolumePercent = PlayerPrefs.GetFloat ("music vol", 1);
            PlayerPrefs.Save ();
        }
    }

    /// <summary>
    /// Sets the volume for the 3 channel (Master/Music/Sfx).
    /// </summary>
    /// <param name="volumePercent">Volume percent.</param>
    /// <param name="channel">Channel.</param>
    public void SetVolume(float volumePercent, AudioChannel channel) {
        switch (channel) {
        case AudioChannel.Master:
            masterVolumePercent = volumePercent;
            break;
        case AudioChannel.Sfx:
            sfxVolumePercent = volumePercent;
            break;
        case AudioChannel.Music:
            musicVolumePercent = volumePercent;
            break;
        }

        musicSources [0].volume = musicVolumePercent * masterVolumePercent;
        musicSources [1].volume = musicVolumePercent * masterVolumePercent;

        PlayerPrefs.SetFloat ("master vol", masterVolumePercent);
        PlayerPrefs.SetFloat ("sfx vol", sfxVolumePercent);
        PlayerPrefs.SetFloat ("music vol", musicVolumePercent);
    }

    /// <summary>
    /// This use the SfxLibrary and you need to assign the string (name of a GroupID) to play the random sounds in it :
    /// AudioManager.instance.PlaySound2D ("groupID of your choice");
    /// </summary>
    /// <param name="clip">Clip.</param>
    /// <param name="pos">Position.</param>
    public void PlaySound2D(string soundName)  {
        sfx2DSource.PlayOneShot (sfxLibrary.GetClipFromName (soundName), sfxVolumePercent * masterVolumePercent);
    }

    /// <summary>
    /// Play the main music in the background.
    /// </summary>
    /// <param name="clip">Clip.</param>
    /// <param name="fadeDuration">Fade duration.</param>
    public void PlayMusic(AudioClip clip, float fadeDuration = 1) {
        musicSources [activeMusicSourceIndex].clip = clip;
        musicSources [activeMusicSourceIndex].Play ();

        StartCoroutine(AnimateMusicCrossfade(fadeDuration));
    }

    /// <summary>
    /// Play the main music + could be use to change music theme smoothly. TEST
    /// Bug known : after the crossfade the 1 audio source doesn't stop and the sound can be changed
    ///  so if one changed the volume the music can overlap. 
    /// </summary>
    /// <param name="clip">Clip.</param>
    /// <param name="fadeDuration">Fade duration.</param>
    public void PlayMusic2(AudioClip clip, float fadeDuration = 1) {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSources [activeMusicSourceIndex].clip = clip;
        musicSources [activeMusicSourceIndex].Play ();

        StartCoroutine(AnimateMusicCrossfade(fadeDuration));

    }

    IEnumerator AnimateMusicCrossfade(float duration) {
        float percent = 0;

        while (percent < 1) {
            percent += Time.deltaTime * 1 / duration;
            musicSources [activeMusicSourceIndex].volume = Mathf.Lerp (0, musicVolumePercent * masterVolumePercent, percent);
            musicSources [1-activeMusicSourceIndex].volume = Mathf.Lerp (musicVolumePercent * masterVolumePercent, 0, percent);
            yield return null;
        }
    }

}
