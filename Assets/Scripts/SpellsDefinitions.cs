using UnityEngine;
using System.Collections;

public class SpellsDefinitions : MonoBehaviour {

	// 3 types of spells/actions
    public static string[] spells1 = { "Spell1_1", "Spell1_2", "Spell1_3", "Spell1_4", "Spell1_5", "Spell1_6", "Spell1_7", "Spell1_8"};
    public static string[] spells2 = { "Spell2_1", "Spell2_2", "Spell2_3", "Spell2_4", "Spell2_5", "Spell2_6", "Spell2_7", "Spell2_8" };
    public static string[] spells3 = { "Spell3_1", "Spell3_2", "Spell3_3", "Spell3_4", "Spell3_5", "Spell3_3", "Spell3_7", "Spell3_8" };

    public static float[] spells1Dmg = { 10.0f, 20.0f, 30.0f, 40.0f, 50.0f, 60.0f, 70.0f, 80.0f };
    public static float[] spells2Dmg = { 15.0f, 25.0f, 35.0f, 45.0f, 55.0f, 65.0f, 75.0f, 85.0f };
    public static float[] spells3Dmg = { 25.0f, 30.0f, 35.0f, 40.0f, 60.0f, 70.0f, 80.0f, 100.0f };

    public static int[] spells1Mana = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public static int[] spells2Mana = { 10, 11, 12, 13, 14, 15, 16, 17 };
    public static int[] spells3Mana = { 20, 21, 22, 23, 24, 25, 26, 25 };

	public static float[] spells1Cooldown = { 1, 2, 3, 4, 5, 6, 7, 8 };
	public static float[] spells2Cooldown = { 10, 11, 12, 13, 14, 15, 16, 17 };
	public static float[] spells3Cooldown = { 20, 21, 22, 23, 24, 25, 26, 25 };

    public static float[] spells1CooldownLeft = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float[] spells2CooldownLeft = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float[] spells3CooldownLeft = { 0, 0, 0, 0, 0, 0, 0, 0 };

	public  GameObject[] monsters;
    
    
    public static float manaPool = 100;

	void Start()
	{
		spells1 = new string[] { "Spell1_1", "Spell1_2", "Spell1_3", "Spell1_4", "Spell1_5", "Spell1_6", "Spell1_7", "Spell1_8"};
		spells2 = new string[] { "Spell2_1", "Spell2_2", "Spell2_3", "Spell2_4", "Spell2_5", "Spell2_6", "Spell2_7", "Spell2_8" };
		spells3 = new string[] { "Spell3_1", "Spell3_2", "Spell3_3", "Spell3_4", "Spell3_5", "Spell3_3", "Spell3_7", "Spell3_8" };

		spells1Mana = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
		spells2Mana = new int[] { 10, 11, 12, 13, 14, 15, 16, 17 };
		spells3Mana = new int[] { 20, 21, 22, 23, 24, 25, 26, 25 };

		spells1Cooldown = new float[] { 1, 2, 3, 4, 5, 6, 7, 8 };
		spells2Cooldown = new float[] { 10, 11, 12, 13, 14, 15, 16, 17 };
		spells3Cooldown = new float[] { 20, 21, 22, 23, 24, 25, 26, 25 };

		spells1CooldownLeft = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };
		spells2CooldownLeft = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };
		spells3CooldownLeft = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };

		manaPool = 100;
	}

    void Update()
    {
        if (manaPool < 100)
        {
            manaPool += Time.deltaTime / 5;
        }

        for (int i = 0; i < spells1CooldownLeft.Length; i++)
        {
            if (spells1CooldownLeft[i] > 0)
            {
                spells1CooldownLeft[i] -= Time.deltaTime;
            }
        }

        for (int i = 0; i < spells2CooldownLeft.Length; i++)
        {
            if (spells2CooldownLeft[i] > 0)
            {
                spells2CooldownLeft[i] -= Time.deltaTime;		
            }
        }

        for (int i = 0; i < spells3CooldownLeft.Length; i++)
        {
            if (spells3CooldownLeft[i] > 0)
            {
                spells3CooldownLeft[i] -= Time.deltaTime;
            }
        }

    }

    void decMana(int value)
    {
        manaPool -= value;
    }

    
}
