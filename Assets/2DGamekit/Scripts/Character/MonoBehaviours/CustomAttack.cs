using UnityEngine;
using Gamekit2D;

public class CustomAttack : MonoBehaviour
{
    private StaminaManager staminaManager;
    private Gamekit2D.PlayerInput playerInput;

    private void Start()
    {
        staminaManager = GetComponent<StaminaManager>();
        playerInput = Gamekit2D.PlayerInput.Instance;
    }

    private void Update()
    {
        if (playerInput == null || staminaManager == null)
            return;

        if (playerInput.MeleeAttack.Down && staminaManager.CanAttack())
        {
            staminaManager.UseStamina();
            Debug.Log("Melee attack used! Stamina now: " + staminaManager.currentStamina);
        }
    }
}
