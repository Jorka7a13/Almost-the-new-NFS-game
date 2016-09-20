using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.Text; 
using System.IO; 

public class xmlParser : MonoBehaviour {
	
	string FileLocation_, FileName_; 
	string money;
	
	// Use this for initialization
	void Start () {
		
	FileLocation_ =registerUser.FileLocation; //get location
	FileName_ = registerUser.FileName;			//get filename
		
	XmlDocument xmlDoc= new XmlDocument(); //* create an xml document object.
	xmlDoc.Load(FileLocation_ +  FileName_);
	//* Get elements.
	XmlNodeList name_ = xmlDoc.GetElementsByTagName("Name");
	XmlNodeList money_ = xmlDoc.GetElementsByTagName("Money"); 
	XmlNodeList lotusStatus_ = xmlDoc.GetElementsByTagName("LotusStatus");
	XmlNodeList lamboStatus_ = xmlDoc.GetElementsByTagName("LamboStatus");
	XmlNodeList fCaStatus_ = xmlDoc.GetElementsByTagName("FerrariCaStatus");
	XmlNodeList f599Status_ = xmlDoc.GetElementsByTagName("Ferrari599Status");
		
	//	print((money_[0]).InnerText);
	//	money = money_[0].InnerText;
		//print(money);
	
//* Display the results.

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
