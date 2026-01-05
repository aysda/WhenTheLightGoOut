using UnityEngine;
using UnityEngine.UI;

public class CircularProgressUI : MonoBehaviour
{
    public Image fillImage;

    void Awake()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        fillImage.fillAmount = 0f;
        gameObject.SetActive(false);
    }

    public void SetProgress(float value)
    {
        fillImage.fillAmount = Mathf.Clamp01(value);
    }
    void OnEnable()
    {
        Debug.Log("CIRCULAR PROGRESS ENABLE OLDU");
    }
}