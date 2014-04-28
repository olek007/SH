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
	public Texture spellReady;
	public Texture spellMana;
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
	}

	void OnMouseDown()
	{
        if (NPCsInside.Count > 0 && SpellsGUI.currentSpell1 >=0)
        {
			if (SpellsDefinitions.spells1CooldownLeft[SpellsGUI.currentSpell1] <= 0)
			{
				if (SpellsDefinitions.spells1Mana[SpellsGUI.currentSpell1] <= manaPool)
				{
					for(int i=0;i<availableItems.Length;i++)
					{
						if(availableItems[i]==true)
						{
							if(SpellsGUI.currentSpell1==i)
							{
								GameObject.Find("Wardrobe/Right_Door").rigidbody.AddRelativeForce(0,0,-0.0001f);
								GameObject.Find("Wardrobe/Left_Door").rigidbody.AddRelativeForce(0,0,-0.0001f);
							}
							RoomAction(SpellsGUI.currentSpell1, SpellsDefinitions.spells1Mana[SpellsGUI.currentSpell1], SpellsDefinitions.spells1Dmg[SpellsGUI.currentSpell1],ref SpellsDefinitions.spells1CooldownLeft[SpellsGUI.currentSpell1],ref SpellsDefinitions.spells1Cooldown[SpellsGUI.currentSpell1]);
						}
						else
						{
							if(SpellsGUI.currentSpell1!=i)
							{
								RoomAction(SpellsGUI.currentSpell1, SpellsDefinitions.spells1Mana[SpellsGUI.currentSpell1], SpellsDefinitions.spells1Dmg[SpellsGUI.currentSpell1],ref SpellsDefinitions.spells1CooldownLeft[SpellsGUI.currentSpell1],ref SpellsDefinitions.spells1Cooldown[SpellsGUI.currentSpell1]);
							}
							break;
						}
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
