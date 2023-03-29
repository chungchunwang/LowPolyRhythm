using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] musicList;
    AudioSource ads;
    int songIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();
        ads.PlayOneShot(musicList[songIndex]);
    }
    // Update is called once per frame
    void Update()
    {
        if(!ads.isPlaying){
            songIndex++;
            if(songIndex == musicList.Length) songIndex = 0;
            ads.PlayOneShot(musicList[songIndex]);
        }
    }
    public void setMusicVolume(int volume){
        ads.volume = volume;
    }
}
