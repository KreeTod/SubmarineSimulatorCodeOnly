using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MenuOrientation : MonoBehaviour
{
    public GameObject HostOrClientPanel;
    public GameObject ClientConnectSettingsPanel;

    [SerializeField] private InputField ipInputField;
    [SerializeField] private InputField portInputField;

    private NetworkManager networkManager;
    public Transport transport;




    private void Start()
    {
        networkManager = GetComponent<NetworkManager>();
    }




    public void StartAsHost()
    {
        /*/ Устанавливаем транспорт в NetworkManager
        if (transport != null)
        {
            networkTransport = transport;
        }*/
        networkManager.StartHost();
    }

    public void StartAsClient()
    {
        string ipAddress = ipInputField.text;
        //int port = int.Parse(portInputField.text);
        networkManager.networkAddress = ipAddress;
        //networkManager.networkPort = port;
        networkManager.StartClient();
    }



    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    public void OpenClientPanel()
    {
        if (ClientConnectSettingsPanel.activeSelf == false)
        {
            ClientConnectSettingsPanel.SetActive(true);
        }
    }
    public void CloseClientPanel()
    {
        if (ClientConnectSettingsPanel.activeSelf == true)
        {
            ClientConnectSettingsPanel.SetActive(false);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    public void OpenHostOrClientPanel()
    {
        if (HostOrClientPanel.activeSelf == false)
        {
            HostOrClientPanel.SetActive(true);
        }
    }
    public void CloseHostOrClientPanel()
    {
        if (HostOrClientPanel.activeSelf == true)
        {
            HostOrClientPanel.SetActive(false);
        }
    }

    public void QuitButtonFunk()
    {
        if (Application.isEditor)
        {
            Debug.Log("We are running this from inside of the editor!");
        }
        else
        {
            Debug.Log("We are running this NOT from inside of the editor!");
        }
    }

}
