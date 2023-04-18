//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//---------------------------------------------------------------------------------
// Author		: XXX
// Date  		: 2015-05-12
// Modified By	: YYY
// Modified Date: 2015-05-12
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
public class FadeScreen : MonoBehaviour
{
    public static FadeScreen instance;
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;
    public AudioSource source;
    public AudioClip clip;

    private void Awake()
    {
        instance = this;
    }
    private IEnumerator Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
        yield return new WaitForSeconds(0.5f);
        source.PlayOneShot(clip);


    }

    public void FadeIn()
    {
        Fade(1, 0);


    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void FadeOutToScene(int sceneIndex, float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(sceneIndex, alphaIn, alphaOut));
    }
    public void FadeOutToScene(string sceneName, float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(sceneName, alphaIn, alphaOut));
    }


    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;

        }
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
    }

    public IEnumerator FadeRoutine(int sceneIndex, float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaOut, alphaIn, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;

        }

        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator FadeRoutine(string sceneName, float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaOut, alphaIn, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;

        }

        SceneManager.LoadScene(sceneName);

    }

}
