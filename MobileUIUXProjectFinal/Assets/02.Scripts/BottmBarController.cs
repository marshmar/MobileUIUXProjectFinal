using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottmBarController : MonoBehaviour
{
    [Header("buttons")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject stopButton;

    public void OnEnable()
    {
        // 바텀바 콘텐츠가 활성화 될때마다 Pause버튼이 활성화되도록.
        EnablePauseButton();
    }

    // 플레이 버튼 활성화
    public void EnablePlayButton()
    {
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    // 일시정지 버튼 활성화
    public void EnablePauseButton()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

}
