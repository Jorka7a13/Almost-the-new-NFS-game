using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.Text; 
using System.IO; 

public class xmlReaderRights : MonoBehaviour {
	
	XmlDocument doc;	
	XmlNodeList xnList;
	
	string xmlString;
	
	string FileLocation_, FileName_; 
	
	string moneyString, lotusStatusString, lamboStatusString, fCaStatusString, f599StatusString;
 	
public static	string name_;
public static	int money_;
public static	int lotusStatus_;
public static	int lamboStatus_;
public static	int fCaStatus_;
public static	int f599Status_;
XmlTextWriter textWriter;	
	
	bool isLoaded;
	
	// Use this for initialization
public void Start () {
		
	isLoaded = false;
		
	FileLocation_ =registerUser.FileLocation; 
	FileName_ = registerUser.FileName;	
		
	XmlDocument xmlDoc= new XmlDocument(); //* create an xml document object.
	//xmlDoc.Load(FileLocation_ + "\\Save\\" + FileName_); //* load the XML document from the specified file.
		xmlDoc.Load(FileLocation_ + FileName_); 

	//* Get elements.
	XmlNodeList Name = xmlDoc.GetElementsByTagName("Name");
	XmlNodeList money = xmlDoc.GetElementsByTagName("Money"); 
	XmlNodeList lotusStatus = xmlDoc.GetElementsByTagName("LotusStatus");
	XmlNodeList lamboStatus = xmlDoc.GetElementsByTagName("LamboStatus");
	XmlNodeList fCaStatus = xmlDoc.GetElementsByTagName("FerrariCaStatus");
	XmlNodeList f599Status = xmlDoc.GetElementsByTagName("Ferrari599Status");	

	name_ = Name[0].InnerText;
		print(name_);
		
	moneyString = money[0].InnerText;
	money_ = int.Parse(moneyString);
	
	lotusStatusString = lotusStatus[0].InnerText;
	lotusStatus_ = int.Parse(lotusStatusString);
	
	lamboStatusString = lamboStatus[0].InnerText;
	lamboStatus_ = int.Parse(lamboStatusString);
	
	fCaStatusString = fCaStatus[0].InnerText;
	fCaStatus_ = int.Parse(fCaStatusString);
	
	f599StatusString = f599Status[0].InnerText;
	f599Status_= int.Parse(f599StatusString);
///////////////////////////////////////////////////////////


//textWriter = new XmlTextWriter(FileLocation_ + "\\Save\\" + FileName_, Encoding.UTF8);
	textWriter = new XmlTextWriter(FileLocation_  + FileName_, Encoding.UTF8);			
				 		textWriter.WriteStartDocument();
				
						textWriter.WriteStartElement("User");
							
							textWriter.WriteStartElement("Name");
								textWriter.WriteString(name_);
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("Money");
								textWriter.WriteString(money_.ToString());
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("LotusStatus");
								textWriter.WriteString(lotusStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("LamboStatus");
								textWriter.WriteString(lamboStatus_.ToString());
							textWriter.WriteEndElement();	

							textWriter.WriteStartElement("FerrariCaStatus");
								textWriter.WriteString(fCaStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("Ferrari599Status");
								textWriter.WriteString(f599Status_.ToString());
							textWriter.WriteEndElement();
								
						textWriter.WriteEndElement(); 
					
					textWriter.WriteEndDocument();
		
		
					textWriter.Close();

	}
	
	// Update is called once per frame
	void Update () {
		Start();
		
	}
}
