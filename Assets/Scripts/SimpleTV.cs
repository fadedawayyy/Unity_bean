using UnityEngine;
using UnityEngine.UI;

public class SimpleTV : MonoBehaviour
{
    public GameObject tvScreen;
    public GameObject[] channels;
    private float savedVolume = 1.0f;
    private bool isMuted = false;
    
    public void PowerButton(bool isOn)
    {
        tvScreen.SetActive(isOn);
    }

   
    public void ShowChannel(int channelIndex)
    {
        
        for (int i = 0; i < channels.Length; i++)
        {
            channels[i].SetActive(false);
        }

        
        if (channelIndex >= 0 && channelIndex < channels.Length)
        {
            channels[channelIndex].SetActive(true);
        }
    } 

    
    public void ChangeVolume(float amount)
    {
        
        AudioListener.volume = AudioListener.volume + amount;

        
        if (AudioListener.volume < 0) AudioListener.volume = 0;
        if (AudioListener.volume > 1) AudioListener.volume = 1;
    }


    public void ToggleMute()
    {
        if(isMuted == false)
        {
            savedVolume = AudioListener.volume;
            AudioListener.volume = 0;
            isMuted = true;
        }
        else
        {
            AudioListener.volume = savedVolume;
            isMuted = false;
        }
    }

}