using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LottiePlugin.UI;

public class ImageAutoPlay : MonoBehaviour
{
    private AnimatedImage animatedImage;
    // Start is called before the first frame update
    void Awake()
    {
        animatedImage = GetComponent<AnimatedImage>();
    }

    private void OnEnable()
    {
        animatedImage.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
