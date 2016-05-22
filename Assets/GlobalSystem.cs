using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GlobalSystem : NetworkBehaviour
{

    bool isAtStartup = true;
    public GameObject ChatLineModel;
    public Transform ChatContainer;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && isAtStartup)
        {
            Debug.Log("Server Started..");
            NetworkServer.Listen(8888);
            NetworkServer.RegisterHandler(MsgType.Ready, OnPlayerReadyMessage);

            isAtStartup = false;
        }
    }

    [ClientCallback]
    void FixedUpdate()
    {
        CmdDisplayClientMessage();
    }

    public void OnPlayerReadyMessage(NetworkMessage netMsg)
    {
        // TODO: create player and call PlayerIsReady()
    }

    [Command]
    public void CmdDisplayClientMessage()
    {
        var NewChatLine = GameObject.Instantiate(ChatLineModel);
        NewChatLine.transform.SetParent(ChatContainer);

    }

}
