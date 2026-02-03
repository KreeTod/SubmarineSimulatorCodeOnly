using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerGUI : MonoBehaviour
{
    [SerializeField] private Text _interactionTextUI;
    private string _interactionText;

    [SerializeField] private GameObject _escapeMenuPanel;
    [SerializeField] private Button _quitButton;
    private bool _isEscapeOpened = false;

    private void Start()
    {
        // Найдем объекты и проверим на null
        _interactionTextUI = GameObject.Find("InteractionText")?.GetComponent<Text>();
        if (_interactionTextUI == null)
        {
            Debug.LogError("InteractionText not found!");
        }

        _escapeMenuPanel = GameObject.Find("EscapePanel");
        if (_escapeMenuPanel == null)
        {
            Debug.LogError("EscapePanel not found!");
        }

        _quitButton = GameObject.Find("QuitButton")?.GetComponent<Button>();
        if (_quitButton == null)
        {
            Debug.LogError("QuitButton not found!");
        }
        else
        {
            _quitButton.onClick.AddListener(QuitTheGame);
        }
    }

    private void Update()
    {
        if (_interactionTextUI != null)
        {
            _interactionTextUI.text = _interactionText;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isEscapeOpened = !_isEscapeOpened;
        }

        if (_escapeMenuPanel != null)
        {
            _escapeMenuPanel.SetActive(_isEscapeOpened);
        }
        else
        {
            _escapeMenuPanel = GameObject.Find("EscapePanel");
            if (_escapeMenuPanel != null)
            {
                _escapeMenuPanel.SetActive(_isEscapeOpened);
            }
        }
    }

    public void SetInteractionText(string value)
    {
        _interactionText = value;
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
