using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class DisplayAreasUI : MonoBehaviour
{
    [SerializeField] public Button _areaButtonPrefab;
    [SerializeField] public GameObject _areas;
    public MainUI mainUI;

    
    public void Awake()
    {
        mainUI = FindObjectOfType<MainUI>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        DisplayAreaButtons();

    }
    private void OnDisable()
    {//*should use separate class kill all buttons
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(transform.GetChild(i).gameObject);
        }
    }
    public void DisplayAreaButtons()
    {

        int childCount = _areas.transform.childCount;
        //foreach Gameobject area in areas create button with method
        for (int i = 0; i < childCount; i++)
        {
            Button spawnedButton = Instantiate(_areaButtonPrefab);
            spawnedButton.transform.parent = this.transform;
            GameObject area = _areas.gameObject.transform.GetChild(i).gameObject;
            spawnedButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = area.name;
            spawnedButton.gameObject.GetComponent<AreaButton>().destination = area;
        }
    }
    void AreaButtonMethod()
    {//this will be completely different
        GameObject passedDestination = _areas;//this will be set by button i suppose

        mainUI.activeUnit.GetComponent<HeroTravel>().destinationArea = passedDestination;
        //pass destination area this
        //pass enum what to do nextTask
    }
}
