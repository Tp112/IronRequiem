using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    public StaminaManager staminaManager;
    public Image staminaFill;

    void Update()
    {
        if (staminaManager != null && staminaFill != null)
        {
            staminaFill.fillAmount = staminaManager.currentStamina / staminaManager.maxStamina;
        }
    }
}
