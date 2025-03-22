using UnityEngine;
using Gamekit2D;

public class StaminaManager : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina = 50f;
    public float staminaRegenRate = 20f;
    public float staminaCostPerAttack = 15f;

    private Gamekit2D.PlayerInput playerInput;

    private void Start()
    {
        currentStamina = maxStamina;
        playerInput = Gamekit2D.PlayerInput.Instance;
    }

    private void Update()
    {
        RegenerateStamina();

        if (playerInput != null)
        {
            if (currentStamina < staminaCostPerAttack)
                playerInput.DisableMeleeAttacking();
            else
                playerInput.EnableMeleeAttacking();
        }
    }

    public bool CanAttack()
    {
        return currentStamina >= staminaCostPerAttack;
    }

    public void UseStamina()
    {
        currentStamina -= staminaCostPerAttack;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }


    private void RegenerateStamina()
    {
        currentStamina += staminaRegenRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }
}
