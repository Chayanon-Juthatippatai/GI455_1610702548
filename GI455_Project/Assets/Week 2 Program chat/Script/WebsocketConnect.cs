using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;


public class WebsocketConnect : MonoBehaviour
{   
    private WebSocket websocket;
    public Text message;
    public Text showMessageMe;
    public Text showMessageOther;
    public Text iPAddress;
    public Text username;
    public Text port;    
    public GameObject firstPage, secPage , errorMess;
    string iPAdd, uName, portRe, sendingMessage, sendMessage, messageChecker;

    void Start()
    {
        firstPage.SetActive(true);
        secPage.SetActive(false);
        messageChecker = showMessageMe.text;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            sendMessage = uName +" : "+message.text;
            SendMassageToSever(sendMessage);            
        }

        if (messageChecker != sendingMessage)
        {
            if(sendingMessage == uName + " : " + message.text)
            {
                UpdateMyChat();
            }
            else
            {
                UpdateOtherChat();
            }
            messageChecker = "";
            sendingMessage = "";

        }

    }


    public void OnDestroy()
    {
        if (websocket != null)
        {
            websocket.Close();
        }
    }

    public void OnMessage(object sender,  MessageEventArgs messageEventArgs)
    {
        sendingMessage = messageEventArgs.Data;

        //if (sendingMessage == uName + " : " + message.text) {
                        
        //    showMessageMe.alignment = TextAnchor.UpperRight;           
            
        //}
        //else
        //{
        //    showMessageMe.alignment = TextAnchor.UpperLeft;           

        //}          
        
    }

    public void SendMassageToSever(string writeMessage)
    {

        writeMessage = uName + " : " + message.text;
        websocket.Send(writeMessage);        

    }

    public void UpdateMyChat()
    {
        showMessageMe.alignment = TextAnchor.UpperRight;
        showMessageMe.text += sendingMessage;
        showMessageMe.text += "\n";
        showMessageOther.text += "\n";

    } 

    public void UpdateOtherChat()
    {
        showMessageOther.alignment = TextAnchor.UpperLeft;
        showMessageOther.text += sendingMessage;
        showMessageOther.text += "\n";
        showMessageMe.text += "\n";

    }

    public void EnterInformation()
    {
        iPAdd = iPAddress.text;
        uName = username.text;
        portRe = port.text;

        //websocket = new WebSocket("ws://127.0.0.1:25500/");
        websocket = new WebSocket("ws://" + iPAdd + ":" +portRe+"/");

        websocket.OnMessage += OnMessage;
        websocket.Connect();

        if(websocket.ReadyState == WebSocketState.Closed)
        {

            errorMess.SetActive(true);   
            
        }

        else
        {

            firstPage.SetActive(false);
            secPage.SetActive(true);

        }
        


    }
}



