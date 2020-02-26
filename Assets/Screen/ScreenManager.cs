using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5)]
    float fadeDuration = 1f;

    [SerializeField]
    Screen initialScreen;

    GameObject activeUI;
    GameObject activeState;

    private void Start()
    {
        ChangeToScreen(initialScreen);
    }

    public void ChangeToScreen(IScreen screen)
    {
        if (activeUI)
            StartCoroutine(FadeOutCanvas(activeUI.GetComponent<Canvas>(), fadeDuration));

        if (activeState)
            Destroy(activeState);

        GameObject targetUI = Instantiate(screen.UI);
        StartCoroutine(FadeInCanvas(targetUI.GetComponent<Canvas>(), fadeDuration));
        activeUI = targetUI;

        activeState = Instantiate(screen.State);
    }

    private IEnumerator FadeOutCanvas(Canvas canvas, float fadeDuration)
    {
        CanvasGroup group = canvas.GetComponent<CanvasGroup>();
        while (group.alpha - Time.deltaTime / fadeDuration >= 0)
        {
            group.alpha -= Time.deltaTime / fadeDuration;
            yield return new WaitForEndOfFrame();
        }
        Destroy(canvas.gameObject);
    }

    private IEnumerator FadeInCanvas(Canvas canvas, float fadeDuration)
    {
        CanvasGroup group = canvas.GetComponent<CanvasGroup>();
        while (group.alpha + Time.deltaTime / fadeDuration <= 1)
        {
            group.alpha += Time.deltaTime / fadeDuration;
            yield return new WaitForEndOfFrame();
        }
        group.alpha = 1;
    }
}
