using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PixelationCaptureSize : MonoBehaviour
{

    public RenderTexture pixelator;
    private int screenHeight = Screen.height;
    private int screenWidth = Screen.width;

    void Start()
    {

        pixelator.height = (int)(screenHeight / (1 / 0.3f));
        pixelator.width = (int)(screenWidth / (1 / 0.3f));

        print(pixelator.width);
        print(pixelator.height);
    }
}
