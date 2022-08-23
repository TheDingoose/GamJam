using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public Image inspectBackground;
    public Image inspectObject;
    public GameObject closeButton;

    public void HideInspect() {
        ToggleInspection(false);
    }

    public void SetInspectionImage(Sprite sprite) {
        inspectObject.sprite = sprite;
        inspectObject.SetNativeSize();
    }

    public void ToggleInspection(bool state, bool doFade = true, float fadeTime = 2f) {
        if (!doFade) fadeTime = 0.0001f;

        StopAllCoroutines();

        closeButton.SetActive(state);
        if (state == true) {
            inspectBackground.raycastTarget = true;
            StartCoroutine(FadeImage(inspectBackground, 50f, fadeTime));
            StartCoroutine(FadeImage(inspectObject, 100f, fadeTime));
        } else {
            inspectBackground.raycastTarget = false;
            StartCoroutine(FadeImage(inspectBackground, 0f, fadeTime));
            StartCoroutine(FadeImage(inspectObject, 0f, fadeTime));
        }
    }

    IEnumerator FadeImage(Image image, float opacity, float fadeSpeed) {
        float timeElapsed = 0;
        while (timeElapsed < fadeSpeed) {
            timeElapsed += Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(image.color.a, opacity/100f, timeElapsed/fadeSpeed));
            yield return null;
        }
    }
}
