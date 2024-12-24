using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Sprite musicOn;
    public Sprite musicOff;
    public GameObject musicButton;

    public Slider slider;

    public AudioSource music;

    void Update()
    {
        music.volume = slider.value;
    }

    public void OnOffMusic()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            musicButton.GetComponent<Image>().sprite = musicOff;
        }
        else
        {
            AudioListener.volume = 1;
            musicButton.GetComponent<Image>().sprite = musicOn;
        }
    }
}
