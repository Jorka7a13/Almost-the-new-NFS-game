using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization; 
using System;
using System.Xml;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public class CryptXML : MonoBehaviour {
	
	string encrypted, decrypted;	
	FileStream stream;
	XmlDocument doc;	
	XmlNodeList xnList;
	
	string xmlString;
	
	string FileLocation_, FileName_; 
	
	string moneyString, lotusStatusString, lamboStatusString, fCaStatusString, f599StatusString;

	// Use this for initialization
	void Start () {
		

		
		
		FileLocation_ = Application.dataPath; 
		FileName_ = "sexMashine.xml";		
					XmlDocument xmlDoc= new XmlDocument(); //* create an xml document object.
					xmlDoc.Load(FileLocation_ + "\\Save\\" + FileName_); //* load the XML document from the specified file.
				stream = new FileStream(FileLocation_ + "\\Save\\" + FileName_, FileMode.Open);
				doc = new XmlDocument();
				doc.Load(stream);
				
				//xnList = doc.SelectNodes("/Cars/Enter_name_here...");
				xnList = doc.SelectNodes("/User");
				xmlString = xnList[0].InnerText;
			
			print(xmlString);
				encrypted = Encrypt(xmlString);
			print(encrypted);
		
		
				decrypted = Decrypt(encrypted);
			print(decrypted);
			
		
	}
	
		public static string Encrypt (string toEncrypt)
	{
		byte[] keyArray = UTF8Encoding.UTF8.GetBytes ("12345678901234567890123456789012");
		// 256-AES key
		byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes (toEncrypt);
		RijndaelManaged rDel = new RijndaelManaged ();
		rDel.Key = keyArray;
		rDel.Mode = CipherMode.ECB;
		// http://msdn.microsoft.com/en-us/library/system.security.cryptography.ciphermode.aspx
		rDel.Padding = PaddingMode.PKCS7;
		// better lang support
		ICryptoTransform cTransform = rDel.CreateEncryptor ();
		byte[] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);
		return Convert.ToBase64String (resultArray, 0, resultArray.Length);
	}

	public static string Decrypt (string toDecrypt)
	{
		byte[] keyArray = UTF8Encoding.UTF8.GetBytes ("12345678901234567890123456789012");
		// AES-256 key
		byte[] toEncryptArray = Convert.FromBase64String (toDecrypt);
		RijndaelManaged rDel = new RijndaelManaged ();
		rDel.Key = keyArray;
		rDel.Mode = CipherMode.ECB;
		// http://msdn.microsoft.com/en-us/library/system.security.cryptography.ciphermode.aspx
		rDel.Padding = PaddingMode.PKCS7;
		// better lang support
		ICryptoTransform cTransform = rDel.CreateDecryptor ();
		byte[] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);
		return UTF8Encoding.UTF8.GetString (resultArray);
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
