using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Script to control game UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Image powerBar;        //ref to powerBar image
    [SerializeField] private Text shotText;         //ref to shot info text
    [SerializeField] private GameObject container, lvlBtnPrefab;    //important gameobjects

    public Text ShotText { get { return shotText; } }   //getter for shotText
    public Image PowerBar { get => powerBar; }          //getter for powerBar

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        powerBar.fillAmount = 0;                        //set the fill amount to zero
    }

    void Start()
    {
        if (GameManager.singleton.gameStatus == GameStatus.None)    //if gamestatus is none
        {   
            GameManager.singleton.currentLevelIndex = 0 ;    //set current level equal to sibling index on button
            LevelManager.instance.SpawnLevel(0);
        }     //we check for game status, failed or complete
        else if (GameManager.singleton.gameStatus == GameStatus.Failed ||
            GameManager.singleton.gameStatus == GameStatus.Complete)
        {
            LevelManager.instance.SpawnLevel(GameManager.singleton.currentLevelIndex);  //spawn level
        }
    }


}
