using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAstral : MonoBehaviour
{
    public GameObject astralPrefab;
    public GameObject wizardPlayer;
    private GameObject astral;
    public Vector2 wizardPosition;
    public static bool astralAlive = false;
    public int counter;
    public int DelayAmount;
    protected float Timer;
    public static int changeValue = 15;

    private LineRenderer line;

    private void spawnAstral()
    {
        astral = Instantiate(astralPrefab) as GameObject; //instantiates the wizard prefab
        if (CharacterController2D.directionCheck == true)
        {
            astral.transform.position = new Vector2(wizardPosition.x + 4, wizardPosition.y); //spawns the prefab infront of the player based on main position
        } else
        {
            astral.transform.position = new Vector2(wizardPosition.x - 4, wizardPosition.y); //spawns the prefab infront of the player based on main position
        }
        
        counter = 0;
        DelayAmount = 1;
    }

    void Start()
    {
        // Add a Line Renderer to the GameObject
        line = this.gameObject.AddComponent<LineRenderer>();

        // Set the width of the Line Renderer
        line.SetWidth(0.2F, 0.2F);

        // Set the number of vertex fo the Line Renderer
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(astralAlive);
        wizardPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && astralAlive == false && UIController.GameIsPaused == false) //for now it spawns the astral body using the Q button
        {
            spawnAstral();
            astralAlive = true;
            FindObjectOfType<AudioManager>().Play("astral");
        }

        if(astralAlive == true && Timer >= DelayAmount)
        {
            Timer = 0f;
            counter = counter + 1;
        }

        if(counter == changeValue)
        {
            Destroy(astral);
            astralAlive = false;
            counter = 0;
            UIController.health = UIController.health - 1;
        }

        Debug.Log(counter);

        if (astralAlive == true)
        {
            // Update position of the two vertex of the Line Renderer
            line.enabled = true;
            line.SetPosition(0, wizardPlayer.transform.position);
            line.SetPosition(1, astral.transform.position);
        }
        else
        {
            line.enabled = false;
        }
    }

    public void DestroyAstra()
    {
        Destroy(astral);
        astralAlive = false;
        counter = 0;
        FindObjectOfType<AudioManager>().Play("astralDestroyed");
    }
}
