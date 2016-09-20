using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 
using System.Text.RegularExpressions;


public class registerUser : MonoBehaviour {
	
//--GUI--	
	int buttonSpacing;
	int buttonWidth;
	int buttonHeight;
	int choosePartsButtonHeight;
	
	bool registerGUI, loginGUI;
	string labelChange;
	
// --XML--		
	public static string _FileLocation,_FileName, FileLocation, FileName; 
	
	XmlTextWriter textWriter;	
	int _money;
	int _lotusStatus;
	int _lamboStatus;
	int _fCaStatus;
	int _f599Status;
	
	string _name;

	void Start () {
		
// -- GUI --		
		buttonSpacing = 5;
		buttonWidth = 350;
		buttonHeight  = 200;
		choosePartsButtonHeight = 50;
		
		registerGUI	= false;
		loginGUI = true;
		labelChange = "Login";
		
//--XML--		
		_name = "Enter Username";
		_money = 20000;
		_lotusStatus = 0;
		_lamboStatus = 0;
		_fCaStatus = 0;
		_f599Status = 0;
		
// --XML--

	
	//_FileLocation=Application.dataPath; 
	_FileLocation = Application.persistentDataPath;


	}
	
	public void OpenSaveFileForWrite() {		
		textWriter = new XmlTextWriter(_FileLocation + _FileName, Encoding.UTF8);
	}
	
	public void CloseSaveFile() {
		textWriter.Close(); 
	}		
	public void WriteToSaveFile() {
		
		textWriter.WriteStartDocument();
				
			textWriter.WriteStartElement("User");
				
				textWriter.WriteStartElement("Name");
					textWriter.WriteString(_name.ToString());
				textWriter.WriteEndElement();
		
				textWriter.WriteStartElement("Money");
					textWriter.WriteString(_money.ToString());
				textWriter.WriteEndElement();
		
				textWriter.WriteStartElement("LotusStatus");
					textWriter.WriteString(_lotusStatus.ToString());
				textWriter.WriteEndElement();
				
				textWriter.WriteStartElement("LamboStatus");
					textWriter.WriteString(_lamboStatus.ToString());
				textWriter.WriteEndElement();	

				textWriter.WriteStartElement("FerrariCaStatus");
					textWriter.WriteString(_fCaStatus.ToString());
				textWriter.WriteEndElement();
				
				textWriter.WriteStartElement("Ferrari599Status");
					textWriter.WriteString(_f599Status.ToString());
				textWriter.WriteEndElement();
					
			textWriter.WriteEndElement(); 
		
		textWriter.WriteEndDocument();
		
		
		textWriter.Close();

	}
	
	
	
	void OnGUI () {	
			
	if(loginGUI){
		
		GUI.Label(new Rect(Screen.width/2-190, Screen.height/3 - 20, 300, 60), labelChange);
		
		GUI.BeginGroup(new Rect(Screen.width/2-190, Screen.height/2-100, 300, 60), ""); 		// Login Interface
		
		GUI.Box(new Rect(0, 0,  300, 60), "");	
		
					_name = GUI.TextField(new Rect (5, 5, 290, 20), _name, 30);
				
					if(GUI.Button (new Rect (5, 30, 142, 25), "Register")) {
						registerGUI = true;
						print(Application.persistentDataPath);
					}
		
				 
					if(GUI.Button (new Rect (153, 30, 142, 25), "Login")) {

				//FileLocation = Application.dataPath; 
				FileLocation = Application.persistentDataPath;
				FileName= _name + ".xml";

					//	if(File.Exists(FileLocation + "\\Save\\" + FileName)){ // if file with that name exists LoadLevel
							if(File.Exists(FileLocation + FileName)){
							Application.LoadLevel("Menu");
							
							}
								else {
										labelChange = "Wrong Username";
									}
							

					
				}
				

				 
						
		GUI.EndGroup();
					
			}
					
		if(registerGUI){
					
		loginGUI = false;	
			
		GUI.Label(new Rect(Screen.width/2-190, Screen.height/3 - 20, 300, 60), "Register");
		
		GUI.BeginGroup(new Rect(Screen.width/2-190, Screen.height/2-100, 300, 60), "");
		
		GUI.Box(new Rect(0, 0,  300, 60), "");	
		
					_name = GUI.TextField(new Rect (5, 5, 290, 20), _name, 30);
		
				 
					if(GUI.Button (new Rect (153, 30, 142, 25), "Register")) {

						_FileName= _name + ".xml";
						//_FileLocation = Application.dataPath; 
						_FileLocation = Application.persistentDataPath;
						OpenSaveFileForWrite();
						WriteToSaveFile();
						
						loginGUI = true;
						registerGUI = false;
						
						//Application.LoadLevel(1);
						
					} 
				 
						
				GUI.EndGroup();
				
			}			
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
