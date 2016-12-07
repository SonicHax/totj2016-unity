using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Model;
using Assets.Scripts.States;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Image hat1;
    public Image hat2;
    public Image hat3;
    public Image vehicle1;
    public Image vehicle2;
    public Image vehicle3;
    public int currentHat;
    public int currentVehicle;
    public new Text name;

    // Use this for initialization
    void Start () {
        vehicle1Click();
        hat1Click();
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}

    public void vehicle1Click()
    {
        toggleVehicleSelection(1);
    }
    public void vehicle2Click()
    {
        toggleVehicleSelection(2);
    }
    public void vehicle3Click()
    {
        toggleVehicleSelection(3);
    }
    public void toggleVehicleSelection(int i)
    {
        switch (i)
        {
            case 1:
                currentVehicle = 1;
                break;
            case 2:
                currentVehicle = 2;
                break;
            case 3:
                currentVehicle = 3;
                break;
        }
    }

    public void hat1Click()
    {
        togglehatSelection(1);
    }
    public void hat2Click()
    {
        togglehatSelection(2);
    }
    public void hat3Click()
    {
        togglehatSelection(3);
    }
    public void togglehatSelection(int i)
    {
        switch (i)
        {
            case 1:
                currentHat = 1;
                break;
            case 2:
                currentHat = 2;
                break;
            case 3:
                currentHat = 3;
                break;
        }
    }

    public void createPlayer()
    {
        if(name.text != "")
        {
            PlayerState.name = name.text;
            PlayerState.hat = currentHat;
            PlayerState.vehicle = currentVehicle;
            
            SQL.Instance.getData("INSERT INTO account (`nickName`, `vehicle`, `hat`) VALUES ('" + PlayerState.name + "'," + PlayerState.vehicle + "," + PlayerState.hat + ")");
            int.TryParse(SQL.Instance.getData("select max(accountID) as result from account"), out PlayerState.id);
            SceneManager.LoadScene("main");
        }
    }
}