using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public bool FadeIn = false;
    public bool FadeOut = false;

    public float TimerToFade;

    void Update()
    {
        if (FadeIn == true) 
        {
            if (CanvasGroup.alpha < 1) 
            {
                CanvasGroup.alpha += TimerToFade * Time.deltaTime;
                if (CanvasGroup.alpha >=1) 
                {
                    FadeIn = false;
                }
            }
        }

        if (FadeOut == true)
        {
            if (CanvasGroup.alpha >= 0)
            {
                CanvasGroup.alpha -= TimerToFade * Time.deltaTime;
                if (CanvasGroup.alpha == 0)
                {
                    FadeOut = false;
                }
            }
        }
    }

    public void FadInTrigger() 
    {
        FadeIn = true;
    }

    public void FadOutTrigger()
    {
        FadeOut = true;
    }
}
