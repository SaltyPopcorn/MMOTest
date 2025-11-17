using UnityEngine;
using TMPro;


using FishNet.Managing;
using FishNet.Transporting.Tugboat;
public class CustomNetworkUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string GetAddress()
    {
        return transform.Find("IPInput").gameObject.GetComponent<TMP_InputField>().text;
    }
    public void StartHost()
    {
        NetworkManager netman = transform.parent.gameObject.GetComponent<NetworkManager>();
        transform.parent.gameObject.GetComponent<Tugboat>().SetClientAddress("localhost");
        netman.ServerManager.StartConnection();
        netman.ClientManager.StartConnection();
        HideMenu();
    }
    public void StartClient()
    {
        NetworkManager netman = transform.parent.gameObject.GetComponent<NetworkManager>();
        transform.parent.gameObject.GetComponent<Tugboat>().SetClientAddress(GetAddress());
        netman.ClientManager.StartConnection();
        HideMenu();
    }
    public void HideMenu()
    {
        gameObject.SetActive(false);
    }
}
