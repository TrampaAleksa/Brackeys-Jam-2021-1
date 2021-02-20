using UnityEngine;
using UnityEngine.UI;

public class SpawnAlliesUi : MonoBehaviour
{
    public static SpawnAlliesUi Instance;
    
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject[] buttonsObjects;
    
    public bool buttonsActive;

    private SpawnAllies _spawnAllies;

    private void Awake()
    {
        Instance = this;
        _spawnAllies = FindObjectOfType<SpawnAllies>();
    }
    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int indexOfButton = i;
           buttons[indexOfButton].onClick.AddListener(() => _spawnAllies.TaskOnClick(indexOfButton));
        }
    }

    public void ChangeButtosActivity()
    {
        for (int i = 0; i < buttonsObjects.Length; i++)
        {
            buttonsObjects[i].SetActive(!buttonsActive);
        }

        buttonsActive = !buttonsActive;
    }
}