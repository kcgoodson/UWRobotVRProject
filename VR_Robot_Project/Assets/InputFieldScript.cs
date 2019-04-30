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

    private void Start()
    {
        this.startSession = GetComponent<Button>();
        this.endSession = GetComponent<Button>();
    }

    public void Setget() {
        this.operatorData = operatorInput.text.ToString();
        this.participantData = participantInput.text.ToString();
        WriteString(operatorData, participantData);
    }

    static void WriteString(string inputO, string inputP){
        string path = "Assets/Resources/data.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Operator-Name:" + inputO + ", Participant-ID:" + inputP);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset) Resources.Load("data");
    }
}