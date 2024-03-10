using UnityEngine;
using UnityEngine.UI;

public class ResourceBarUI : MonoBehaviour
{
    private Image barImage;

    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();
    }

    public void SetBarAmount(float valueNormalized)
    {
        barImage.fillAmount = valueNormalized;
    }
}
