using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 
using System.Text.RegularExpressions;

public class BuyScript :MonoBehaviour {

	private int lotusPrice,lamboPrice, fCaPrice, f599Price;

	public static string _FileLocation,_FileName;
	
	XmlTextWriter textWriter;	
	int _money;
	int _lotusStatus;
	int _lamboStatus;
	int _fCaStatus;
	int _f599Status;
	int money;
	
	string _name;
	
	// Use this for initialization
	void Start () {
		

		
		lotusPrice = 75000;
		lamboPrice = 354000;
		fCaPrice=200000;
		f599Price = 410000;
		money = 0;
		
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
		
	
		
		if(GUI.Button(new Rect(0, 205,Screen.width-1150, Screen.height-500), "Buy")) {
					
			//////////////////////// LOTUS
			if(ChooseCar.CarSelectionGridInt==1 && xmlReaderRights.lotusStatus_ ==0 && xmlReaderRights.money_ >= lotusPrice){ // Selected Lotus, not already bought, you have enogh money
				
						xmlReaderRights reader = new xmlReaderRights();
						reader.Start();
				
						xmlReaderRights.money_ = xmlReaderRights.money_ - lotusPrice;
						xmlReaderRights.lotusStatus_ = 1;
				
						//textWriter = new XmlTextWriter(_FileLocation + "\\Save\\" + _FileName, Encoding.UTF8);
				textWriter = new XmlTextWriter(_FileLocation  + _FileName, Encoding.UTF8);
				 		textWriter.WriteStartDocument();
				
						textWriter.WriteStartElement("User");
							
							textWriter.WriteStartElement("Name");
								textWriter.WriteString(xmlReaderRights.name_);
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("Money");
								textWriter.WriteString(xmlReaderRights.money_.ToString());
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("LotusStatus");
								textWriter.WriteString(xmlReaderRights.lotusStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("LamboStatus");
								textWriter.WriteString(xmlReaderRights.lamboStatus_.ToString());
							textWriter.WriteEndElement();	

							textWriter.WriteStartElement("FerrariCaStatus");
								textWriter.WriteString(xmlReaderRights.fCaStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("Ferrari599Status");
								textWriter.WriteString(xmlReaderRights.f599Status_.ToString());
							textWriter.WriteEndElement();
								
						textWriter.WriteEndElement(); 
					
					textWriter.WriteEndDocument();
		
		
					textWriter.Close();
					
					Application.LoadLevel("ChooseCar");

					
			}
			///////////////// LAMBO
			if(ChooseCar.CarSelectionGridInt==2 && xmlReaderRights.lamboStatus_ ==0 && xmlReaderRights.money_ >= lamboPrice){ // Selected Lotus, not already bought, you have enogh money
							
						xmlReaderRights reader = new xmlReaderRights();
						reader.Start();				
				
						xmlReaderRights.money_ = xmlReaderRights.money_ - lamboPrice;
						xmlReaderRights.lamboStatus_ = 1;
				
					//	textWriter = new XmlTextWriter(_FileLocation + "\\Save\\" + _FileName, Encoding.UTF8);
				textWriter = new XmlTextWriter(_FileLocation  + _FileName, Encoding.UTF8);
				 		textWriter.WriteStartDocument();
				
						textWriter.WriteStartElement("User");
							
							textWriter.WriteStartElement("Name");
								textWriter.WriteString(xmlReaderRights.name_);
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("Money");
								textWriter.WriteString(xmlReaderRights.money_.ToString());
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("LotusStatus");
								textWriter.WriteString(xmlReaderRights.lotusStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("LamboStatus");
								textWriter.WriteString(xmlReaderRights.lamboStatus_.ToString());
							textWriter.WriteEndElement();	

							textWriter.WriteStartElement("FerrariCaStatus");
								textWriter.WriteString(xmlReaderRights.fCaStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("Ferrari599Status");
								textWriter.WriteString(xmlReaderRights.f599Status_.ToString());
							textWriter.WriteEndElement();
								
						textWriter.WriteEndElement(); 
					
					textWriter.WriteEndDocument();
		
		
					textWriter.Close();

					Application.LoadLevel("ChooseCar");
	
					
			}
			//////////////////FCA
						if(ChooseCar.CarSelectionGridInt==3 && xmlReaderRights.fCaStatus_ ==0 && xmlReaderRights.money_ >= fCaPrice){ // Selected Lotus, not already bought, you have enogh money
				
							xmlReaderRights reader = new xmlReaderRights();
							reader.Start();
							
						xmlReaderRights.money_ = xmlReaderRights.money_ - fCaPrice;
						xmlReaderRights.fCaStatus_ = 1;
				
						//textWriter = new XmlTextWriter(_FileLocation + "\\Save\\" + _FileName, Encoding.UTF8);
				textWriter = new XmlTextWriter(_FileLocation  + _FileName, Encoding.UTF8);
				 		textWriter.WriteStartDocument();
				
						textWriter.WriteStartElement("User");
							
							textWriter.WriteStartElement("Name");
								textWriter.WriteString(xmlReaderRights.name_);
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("Money");
								textWriter.WriteString(xmlReaderRights.money_.ToString());
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("LotusStatus");
								textWriter.WriteString(xmlReaderRights.lotusStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("LamboStatus");
								textWriter.WriteString(xmlReaderRights.lamboStatus_.ToString());
							textWriter.WriteEndElement();	

							textWriter.WriteStartElement("FerrariCaStatus");
								textWriter.WriteString(xmlReaderRights.fCaStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("Ferrari599Status");
								textWriter.WriteString(xmlReaderRights.f599Status_.ToString());
							textWriter.WriteEndElement();
								
						textWriter.WriteEndElement(); 
					
					textWriter.WriteEndDocument();
		
		
					textWriter.Close();
					
					Application.LoadLevel("ChooseCar");

			}
						if(ChooseCar.CarSelectionGridInt==4 && xmlReaderRights.f599Status_ ==0 && xmlReaderRights.money_ >= f599Price){ // Selected Lotus, not already bought, you have enogh money
				
									xmlReaderRights reader = new xmlReaderRights();
									reader.Start();	
							
						xmlReaderRights.money_ = xmlReaderRights.money_ - f599Price;
						xmlReaderRights.f599Status_ = 1;
				
					//	textWriter = new XmlTextWriter(_FileLocation + "\\Save\\" + _FileName, Encoding.UTF8);
				textWriter = new XmlTextWriter(_FileLocation  + _FileName, Encoding.UTF8);
				 		textWriter.WriteStartDocument();
				
						textWriter.WriteStartElement("User");
							
							textWriter.WriteStartElement("Name");
								textWriter.WriteString(xmlReaderRights.name_);
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("Money");
								textWriter.WriteString(xmlReaderRights.money_.ToString());
							textWriter.WriteEndElement();
					
							textWriter.WriteStartElement("LotusStatus");
								textWriter.WriteString(xmlReaderRights.lotusStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("LamboStatus");
								textWriter.WriteString(xmlReaderRights.lamboStatus_.ToString());
							textWriter.WriteEndElement();	

							textWriter.WriteStartElement("FerrariCaStatus");
								textWriter.WriteString(xmlReaderRights.fCaStatus_.ToString());
							textWriter.WriteEndElement();
							
							textWriter.WriteStartElement("Ferrari599Status");
								textWriter.WriteString(xmlReaderRights.f599Status_.ToString());
							textWriter.WriteEndElement();
								
						textWriter.WriteEndElement(); 
					
					textWriter.WriteEndDocument();
		
		
					textWriter.Close();
					
					Application.LoadLevel("ChooseCar");

			}
			
			xmlReaderRights readerXml = new xmlReaderRights();
			readerXml.Start();
	
		}

	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
