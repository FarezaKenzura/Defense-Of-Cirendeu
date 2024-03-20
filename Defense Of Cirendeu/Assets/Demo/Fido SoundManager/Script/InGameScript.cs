using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScript : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void OpenPauseMenu() {
        pauseMenu.SetActive(true);
        SoundManager.instance.PlaySFX(0);
    }

    public void ClosePauseMenu() {
        pauseMenu.SetActive(false);
        SoundManager.instance.PlaySFX(0);
    }

    public void BoomButton() {
        SoundManager.instance.PlaySFX(1);
    }
}
