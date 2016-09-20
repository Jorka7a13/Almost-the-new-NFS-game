using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 
using System.Text.RegularExpressions;


public class ChooseTrackTunning : MonoBehaviour {
	
	public static string _FileLocation,_FileName;
	
	XmlTextWriter textWriter;	
	string _name;
	int _money;
	int _lotusStatus;
	int _lamboStatus;
	int _fCaStatus;
	int _f599Status;
	int money;
	
	public string[] Thumbnails;
		
	public static int SelectionGridInt;
	
	public static int _CarSelectionGridInt; 
	
	int buttonSpacing, buttonWidth, buttonHeight;
	// Use this for initialization
	void Start () {
		
		SelectionGridInt = 3;
		
		Thumbnails = new string[] {"Track One","Night Track"};
		buttonSpacing = 5;
		buttonWidth = 400;
		buttonHeight = 400;
	
		_name = xmlReaderRights.name_;
		_money = xmlReaderRights.money_;
		_lotusStatus = xmlReaderRights.lotusStatus_;
		_lamboStatus = xmlReaderRights.lamboStatus_;
		_fCaStatus = xmlReaderRights.fCaStatus_;
		_f599Status = xmlReaderRights.f599Status_;
		
		_FileLocation =registerUser.FileLocation; 
		_FileName = registerUser.FileName;	
	}
	
		void OnGUI(){
		
		GUI.BeginGroup (new Rect (Screen.width / 4 - 50, Screen.height / 4 - 50, 800, 800));
		// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

		// We'll make a box so you can see where the group is on-screen.
		GUI.Box (new Rect (0,0,800,800), "Choose Track");
		SelectionGridInt = GUI.SelectionGrid(new Rect (10,40,800,400),SelectionGridInt, Thumbnails,2);

		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
		
		
		}
	
	// Update is called once per frame
	void Update () {
		
		if(SelectionGridInt==0) { // Start
		
		Application.LoadLevel("CompleteSceneTuninged");
			
									money = xmlReaderRights.money_ +20000;
						
						textWriter = new XmlTextWriter(_FileLocation + "\\Save\\" + _FileName, Encoding.UTF8);
				
				 		textWriter.WriteStartDocument();
				
						textWriter.WriteStartElement("User");
							
							textWriter.WriteStartElement("Name");
								textWriter.WriteString(_name);
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("Money");
								textWriter.WriteString(money.ToString());
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
		
		if(SelectionGridInt==1) { // Start
		
		Application.LoadLevel("CompleteSceneTuningedNight");
			
									money = xmlReaderRights.money_ +20000;
						
						textWriter = new XmlTextWriter(_FileLocation + "\\Save\\" + _FileName, Encoding.UTF8);
				
				 		textWriter.WriteStartDocument();
				
						textWriter.WriteStartElement("User");
							
							textWriter.WriteStartElement("Name");
								textWriter.WriteString(_name);
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("Money");
								textWriter.WriteString(money.ToString());
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
	
	}
}
