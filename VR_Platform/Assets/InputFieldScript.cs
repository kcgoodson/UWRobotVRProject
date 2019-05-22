using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.
using System.IO;
using UnityEditor;

public class InputFieldScript : MonoBehaviour
{
    public InputField operatorInput, participantInput;
    public Button startSession, endSession;
    string operatorData;
    string participantData;

    public void Setget()
    {
        this.operatorData = operatorInput.text.ToString();
        this.participantData = participantInput.text.ToString();
        WriteInitial(operatorData, participantData);
    }

    static void WriteInitial(string inputO, string inputP)
    {
        string path = "Assets/Resources/data.txt";

        //Write some text to the data.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Operator-Name:" + inputO + ", Participant-ID:" + inputP
                          +  ", Time:" + System.DateTime.Now);
  
        writer.Close();

        //Re-import the file to update the reference in the editor
        Resources.Load(path);
        //AssetDatabase.Import(path);
        TextAsset asset = (TextAsset)Resources.Load("data.txt");
 
    }

    public void OnClickCount(Button clickedButton)
    {
        string path = "Assets/Resources/data.txt";

        //Write some text to the data.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Button: " + clickedButton.name + " Click: 1");
        writer.Close();

        //Re-import the file to update the reference in the editor
        Resources.Load(path);
        //AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("data");

    }

    public void EndSessioWrite()
    {
        string path = "Assets/Resources/data.txt";

        //Write some text to the data.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Session Ended --" + " Time:" + System.DateTime.Now);
        writer.Close();

        //Re-import the file to update the reference in the editor
        Resources.Load(path);
        //AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("data");

        operatorInput.text = "";
        participantInput.text = "";
        startSession.interactable = true;
        endSession.interactable = true;
    }


}