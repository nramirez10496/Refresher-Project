using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Stat maxHealth;
    [SerializeField] Stat currentHealth;

    private Coroutine damageCoroutine;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth.amount = maxHealth.amount;//start with full health 
    }
    IEnumerator DrainHealth()
    {
        while (currentHealth.amount > 0)
        {
            yield return new WaitForSeconds(2.0f);

            if (currentHealth.amount > 0)
            {
                DamagePlayer(10);
            }
        }
        damageCoroutine = null;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth.amount -= damage;
        currentHealth.amount= Mathf.Max(currentHealth.amount, 0);
    }

    public void StartDamage()
    {
        DamagePlayer(5);

        if(damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(DrainHealth());
        }
    }

    public void StopDamage()
    {
        StopCoroutine(damageCoroutine);
        damageCoroutine = null;
    }
}
