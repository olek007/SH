using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room_Scare : MonoBehaviour {

	public bool[] availableItems;
    public GameObject mana;
	private List<GameObject> NPCsInside = new List<GameObject>();
	private float dmg;
    private float manaPool;
	private float spellReadyTimer;
	private float spellManaTimer;
	private float spellAvailableTimer;
	public Texture spellReady;
	public Texture spellMana;
	public Texture spellAvailable;
	private Vector3 mousePos;



	void Start()
	{
		spellManaTimer = 0.0f;
		spellReadyTimer = 0.0f;

	}

    void Update()
    {
        manaPool = SpellsDefinitions.manaPool;
    }


	void OnTriggerEnter(Collider collider)
	{
        if (collider.tag == "GameController" && collider.GetComponent<NPC_AI>().fearLevel < 100)
        {
            NPCsInside.Add(collider.gameObject);

        }
	}
	void OnTriggerExit(Collider collider)
	{
        if (collider.tag == "GameController")
        {
            NPCsInside.Remove(collider.gameObject);

		}
	}

	void OnGUI()
	{
		if (spellReadyTimer > 0)
		{
			GUI.Label(new Rect((Screen.width - spellReady.width) / 2, (Screen.height - spellReady.height) / 2, spellReady.width, spellReady.height), spellReady);
			spellReadyTimer -= Time.deltaTime;
		}
		else
			if (spellManaTimer > 0)
			{
				GUI.Label(new Rect((Screen.width - spellMana.width) / 2, (Screen.height - spellMana.height) / 2, spellMana.width, spellMana.height), spellMana);
				spellManaTimer -= Time.deltaTime;
			}

		if (spellAvailableTimer > 0)
		{
			GUI.Label(new Rect((Screen.width - spellAvailable.width) / 2, (Screen.height - spellAvailable.height) / 2, spellAvailable.width, spellAvailable.height), spellAvailable);
			spellAvailableTimer -= Time.deltaTime;
		}
	}

	void OnMouseDown()
	{
        if (NPCsInside.Count > 0 && SpellsGUI.currentSpell1 >=0)
        {
			if (SpellsDefinitions.spells1CooldownLeft[SpellsGUI.currentSpell1] <= 0)
			{
				if (SpellsDefinitions.spells1Mana[SpellsGUI.currentSpell1] <= manaPool)
				{
					if (availableItems[SpellsGUI.currentSpell1] == true)
					{

						switch (SpellsGUI.currentSpell1)
						{
							case 0:		//Swiatlo
								{
									GameObject.Find(gameObject.name + "/Point light").SendMessage("TurnOff");
									foreach (GameObject NPC in NPCsInside)
									{
										NPC.SendMessage("increaseFearSusceptibility", 0.1 / NPCsInside.Count);
									}
								}
								break;
							case 1:		//Szafa
								{
									GameObject.Find(gameObject.name + "/Wardrobe/Right_Door").SendMessage("openWardrobe");
									GameObject.Find(gameObject.name + "/Wardrobe/Left_Door").SendMessage("openWardrobe");
									foreach (GameObject NPC in NPCsInside)
									{
										NPC.SendMessage("increaseFearSusceptibility", 0.2 / NPCsInside.Count);
									}
								}
								break;
							case 2:		//Kuchenka
								{
									GameObject.Find(gameObject.name + "/Oven/Spawn fire").SendMessage("explosionOven");
									foreach (GameObject NPC in NPCsInside)
									{
										NPC.SendMessage("increaseFearSusceptibility", 0.3 / NPCsInside.Count);
									}
								}
								break;
						};

						RoomAction(SpellsGUI.currentSpell1, SpellsDefinitions.spells1Mana[SpellsGUI.currentSpell1], SpellsDefinitions.spells1Dmg[SpellsGUI.currentSpell1],ref SpellsDefinitions.spells1CooldownLeft[SpellsGUI.currentSpell1],ref SpellsDefinitions.spells1Cooldown[SpellsGUI.currentSpell1]);
					}
					else
					{
						spellAvailableTimer = 2.0f;
					}	
				}else
				{
					spellManaTimer = 2.0f;
				}
			}else
			{
				spellReadyTimer = 2.0f;
			}
        }

		if (SpellsGUI.currentSpell2 >= 0)
		{
			MonsterAction(SpellsGUI.currentSpell2, SpellsDefinitions.spells2Mana[SpellsGUI.currentSpell2], SpellsDefinitions.spells2Dmg[SpellsGUI.currentSpell2],ref  SpellsDefinitions.spells2CooldownLeft[SpellsGUI.currentSpell2],ref  SpellsDefinitions.spells2Cooldown[SpellsGUI.currentSpell2]);
		}
		
	}

	void RoomAction(int selectedSpell, int spellCost, float spellDMG,ref float spellCDLeft,ref float spellCD)
	{
		
			spellCDLeft = spellCD;
			mana.SendMessage("decMana", spellCost);
			foreach (GameObject NPC in NPCsInside)
			{
				if (Mathf.CeilToInt(NPC.GetComponent<NPC_AI>().fearLevel) < 100)
				{
					NPC.SendMessage("addFear", spellDMG / NPCsInside.Count);
				}
				else
				{
					NPCsInside.Remove(NPC);
				}
			}
	}


	void MonsterAction(int selectedSpell, int spellCost, float spellDMG, ref float spellCDLeft,ref  float spellCD)
	{
		if (spellCDLeft <= 0)
		{
			if (spellCost <= manaPool)
			{
				spellCDLeft = spellCD;
				mana.SendMessage("decMana", spellCost);

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.gameObject.layer == 9)
					{
						Instantiate(mana.GetComponent<SpellsDefinitions>().monsters[selectedSpell], new Vector3 (hit.point.x,hit.point.y-1.0f,hit.point.z), transform.rotation);
					}
				}
			}
			else
			{
				spellManaTimer = 2.0f;
			}
		}
		else
		{
			spellReadyTimer = 2.0f;
		}
		

	}
}
