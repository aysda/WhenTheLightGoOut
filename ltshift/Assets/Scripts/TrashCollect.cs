using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TrashCollect : MonoBehaviour
{
    public float collectTime = 5f;
    public CircularProgressUI progressUI;

    float currentTime = 0f;
    bool isCollecting = false;

    bool isHoldingE = false;

    public void BeginCollect()
    {
        if (progressUI == null)
        {
            Debug.LogError("ProgressUI BAĞLI DEĞİL!");
            return;
        }

        if (isCollecting) return;

        isCollecting = true;
        progressUI.Show();

        Debug.Log("COLLECT BAŞLADI");
    }

    public void CancelCollect()
    {
        isCollecting = false;
        currentTime = 0f;

        if (progressUI != null)
            progressUI.Hide();
    }

    void Update()
    {
        if (!isCollecting || progressUI == null || Keyboard.current == null)
            return;

        // E'ye ilk basıldığı an
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            isHoldingE = true;
            Debug.Log("E BASILDI (HOLD BAŞLADI)");
        }

        // E bırakıldığı an
        if (Keyboard.current.eKey.wasReleasedThisFrame)
        {
            Debug.Log("E BIRAKILDI (RESET)");
            isHoldingE = false;
            CancelCollect();
            return;
        }

        // Basılı tutulduğu sürece
        if (isHoldingE)
        {
            Debug.Log("E BASILI TUTULUYOR");

            currentTime += Time.deltaTime;
            progressUI.SetProgress(currentTime / collectTime);

            if (currentTime >= collectTime)
            {
                progressUI.Hide();
                Destroy(gameObject);
            }
        }
    }
}