using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    private List<GameObject> _models;
    // Default index
    private int _selectionIndex;
    private int _currentValue;

    [SerializeField]
    private Dropdown _dropdown;

    [SerializeField]
    private Button _playButton;

    private void Start()
    {
        _models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            _models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        _models[_selectionIndex].SetActive(true);
        _playButton.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(0);
    }

    private void Update()
    {
        if (_dropdown.value != _currentValue)
        {
            _currentValue = _dropdown.value;
            Select(_dropdown.value);
        }
    }

    public void Select(int index)
    {
        if (index == _selectionIndex) return;
        if (index < 0 || index >= _models.Count) return;

        _models[_selectionIndex].SetActive(false);
        _selectionIndex = index;
        _models[_selectionIndex].SetActive(true);
    }
}
