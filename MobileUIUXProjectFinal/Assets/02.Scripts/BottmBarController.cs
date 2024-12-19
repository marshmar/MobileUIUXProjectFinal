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
        // ���ҹ� �������� Ȱ��ȭ �ɶ����� Pause��ư�� Ȱ��ȭ�ǵ���.
        EnablePauseButton();
    }

    // �÷��� ��ư Ȱ��ȭ
    public void EnablePlayButton()
    {
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    // �Ͻ����� ��ư Ȱ��ȭ
    public void EnablePauseButton()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

}
