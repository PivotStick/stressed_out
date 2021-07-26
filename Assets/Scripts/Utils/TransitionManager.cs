using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private RawImage blackscreen;

    public static TransitionManager instance = null;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void FadeIn(float time = 3)
    {
        blackscreen.gameObject.SetActive(true);
        SetOpacityTo(1, time);
    }

    public void FadeOut(float time = 3)
    {
        SetOpacityTo(0, time, active: false);
    }

    private void SetOpacityTo(float value, float time, bool active = true)
    {
        StartCoroutine(LerpOpacityTo(value, time, active));
    }

    private IEnumerator LerpOpacityTo(float value, float time, bool active)
    {
        value = Mathf.Clamp01(value);
        float t = 0;
        var initialColor = blackscreen.color;
        var targetColor = new Color(
            initialColor.r,
            initialColor.g,
            initialColor.b,
            value
        );

        while (blackscreen.color.a != value)
        {
            t += Time.deltaTime;
            blackscreen.color = Color.Lerp(initialColor, targetColor, Mathf.Clamp01(t / time));
            yield return new WaitForEndOfFrame();
        }

        blackscreen.gameObject.SetActive(active);
    }

    public IEnumerator GameOver()
    {
        FadeIn();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        FadeOut();
        CanvasManager.instance.gameObject.SetActive(true);
    }
}
