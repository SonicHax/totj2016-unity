using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.States;
using UnityEngine.SceneManagement;
using Assets.Scripts.Model;

public class HostController : MonoBehaviour {

    public Text roomName;
    public Dropdown players;
    public Room room;

	// Use this for initialization
	void Start () {
        room = new Room();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateLobby()
    {
        if(roomName.text != "")
        {
            room.name = roomName.text;
            room.players = players.value;
            room.active = "true";
            room.host = PlayerState.id;
            room.host = 1;
            RoomState.name = room.name;
            RoomState.players = room.players;
            RoomState.active = "true";
            RoomState.host = PlayerState.id;
            RoomState.host = 1;
            SQL.Instance.getData("INSERT INTO `room`(`name`, `active`, `players`, `host`, `started`) VALUES ('" + room.name + "', true, " + room.players + "," + room.host + ", false)");
            SceneManager.LoadScene("lobby");
        }
    }
}
