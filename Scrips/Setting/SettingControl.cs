using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject setCanvs;
    public Slider musicSlider, sfxSlider;
    public Image musicImage, sfxImage;
    public Sprite musicSprite, sfxSprite;
    private bool musicSpriteIsChanged=false;
    private bool sfxSpriteIsChanged=false;

    void OnEnable()
    {
		//時間暫停
        Time.timeScale = 0f;
    }
    
    void OnDisable()
    {
		//時間以正常速度運行
        Time.timeScale = 1f;
    }

    void Start()
    {
        setCanvs.SetActive(false);
    }
    public void EnterSet()
    {
        setCanvs.SetActive(true);
        OnEnable();
    }
    public void ExitSet()
    {
        setCanvs.SetActive(false);
        OnDisable();
    }
    
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
    }
    public void ChangeMusicSprite(Sprite sprite)
    {
        if(!musicSpriteIsChanged){
            musicImage.sprite = sprite;
            musicSpriteIsChanged=true;
        }else{
            musicImage.sprite = musicSprite;
            musicSpriteIsChanged=false;
        }
        
    }
    public void ChangeSFXSprite(Sprite sprite)
    {
        if(!sfxSpriteIsChanged){
            sfxImage.sprite = sprite;
            sfxSpriteIsChanged=true;
        }else{
            sfxImage.sprite = sfxSprite;
            sfxSpriteIsChanged=false;
        }
    }

}
