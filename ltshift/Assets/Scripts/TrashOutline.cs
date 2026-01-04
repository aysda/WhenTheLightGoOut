using UnityEngine;

public class TrashOutline : MonoBehaviour
{
    Renderer rend;
    Material mat;

    public Color emissionColor = Color.yellow;
    public float emissionIntensity = 2f;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        // BURASI KRİTİK: material → instance oluşturur
        mat = rend.material;

        DisableEmission();
    }

    public void EnableEmission()
    {
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", emissionColor * emissionIntensity);
    }

    public void DisableEmission()
    {
        mat.DisableKeyword("_EMISSION");
    }
}