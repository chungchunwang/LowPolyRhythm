using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{    
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider[] masterVolumeSliders;
    [SerializeField] Slider[] musicVolumeSliders;
    [SerializeField] Slider[] sfxVolumeSliders;
    private static AudioManager instance = null;
    private void Awake() {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
        private void Start() {
        foreach(Slider sldr in masterVolumeSliders){
            sldr.onValueChanged.AddListener(setMasterVolume);
        }
        foreach(Slider sldr in musicVolumeSliders){
            sldr.onValueChanged.AddListener(setMusicVolume);
        }
        foreach(Slider sldr in sfxVolumeSliders){
            sldr.onValueChanged.AddListener(setSFXVolume);
        }
    }
    public void setMasterVolume(float volumeIndex){
        if(volumeIndex < float.Epsilon) volumeIndex = 0.00001f;
        audioMixer.SetFloat("Master Volume", Mathf.Log10(volumeIndex) * 20);
    }
    public void setMusicVolume(float volumeIndex){
        if(volumeIndex < float.Epsilon) volumeIndex = 0.00001f;
        audioMixer.SetFloat("Music Volume", Mathf.Log10(volumeIndex) * 20);
    }
    public void setSFXVolume(float volumeIndex){
        if(volumeIndex < float.Epsilon) volumeIndex = 0.00001f;
        audioMixer.SetFloat("SFX Volume", Mathf.Log10(volumeIndex) * 20);
    }
}

