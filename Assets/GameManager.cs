using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTT.MinigameMemory;
using Naninovel;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    [SerializeField] MemoryGameManager miniGameManager;
    [SerializeField] MemoryGameSettings miniGameSettings;

    [SerializeField] GameObject interactiveObject;

    public string objective {get; private set;}
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        objective = "None";
        MemoryGameManager.Instance.Finish += MiniGameManager_Finish;
        var characters = Engine.GetService<ICharacterManager>();
        Engine.GetService<ICustomVariableManager>().OnVariableUpdated += GameManager_OnVariableUpdated;
    }

    private void MiniGameManager_Finish(MemoryGameResults obj)
    {
        Engine.GetService<ICustomVariableManager>().SetVariableValue("clearedMinigame", "true");
        var switchCommand = new SwitchToNovelMode {  };
        switchCommand.ExecuteAsync(default).Forget();
    }

    private void GameManager_OnVariableUpdated(CustomVariableUpdatedArgs obj)
    {
        Debug.Log(obj.Name + " = " + obj.Value);
        /*switch (obj.Name)
        {
            case "hasToExploreTheCity":
                if (obj.Value == "True") objective = "Explore the city";       
            break;

            case "hasToFindItem":
                if (obj.Value == "True") objective = "Find the ring";
                break;
            case "hasItem":
                if (obj.Value == "True") objective = "Return to Isolde with the ring";
                break;
            case "isoldeMissing":
                if (obj.Value == "True") objective = "Find Isolde";
                break;
            case "questCompleted":
                if (obj.Value == "True") objective = "Quest completed";
                break;
            default:
                break;

        }*/
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void StartMiniGame()
    {
        Debug.Log("starting game");
        //Start Minigame
        MemoryGameManager.Instance.StartGame(miniGameSettings);
        
    }

    public void StopMiniGame()
    {
        Debug.Log("stopping game");
        //Start Minigame
        MemoryGameManager.Instance.Stop();
    }
}
