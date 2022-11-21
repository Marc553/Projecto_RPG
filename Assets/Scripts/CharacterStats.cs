using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int level;
    public int exp;
    public int[] expToLevelUp;
    public int[] maxHealthLevel;
    private HealthManager _healthManager;

    private void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        AddExperience(0);
    }

    public void AddExperience(int expToAdd)
    {
        exp += expToAdd;
        if (level >= expToLevelUp.Length) { return; }
        if (exp >= expToLevelUp[level])
        {
        _healthManager.UpdateMaxHealth(maxHealthLevel[level]);
        level++;
            exp -= expToLevelUp[level - 1];
        }
    }

}
