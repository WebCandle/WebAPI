using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WebAPI.Controllers
{
    public class MainController
    {
        public List<Chat> Chats { get; set; }
        public MainController()
        {
            Chats = new List<Chat>();
            LoadChats();
        }
        public void LoadChats()
        {
            Chat chat1 = new Chat(1, "Fussbal", new List<Message>());
            AddChat(chat1);
            Chat chat2 = new Chat(2, "Handball", new List<Message>());
            AddChat(chat2);
            Chat chat3 = new Chat(3, "Tennis", new List<Message>());
            AddChat(chat3);
        }
        public void AddChat(Chat chat)
        {
            Chats.Add(chat);
        }
        public void PostMessage(string endpoint, long chatId, string messageText,long senderid)
        {
            
            Message message = new Message(messageText, senderid);
            string requestXML = MessageToXMLString(message);
            string destinationUrl = endpoint + "/api/Message/" + chatId.ToString();
            string result = postXMLData(destinationUrl, requestXML);
        }
        public string postXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }
        public string MessageToXMLString(Message message)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(Message));
                serializer.Serialize(stringwriter, message);
                return stringwriter.ToString();
            }
        }

        public static Message MessageFromXMLString(string xmlText)
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(Message));
                return serializer.Deserialize(stringReader) as Message;
            }
        }
    }
}