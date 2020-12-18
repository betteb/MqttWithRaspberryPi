using System;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ch.nevem.mqtt.simple
{
    class Program
    {
        static void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
           // Console.Writeline(Encoding.UTF8.GetString(sender.Payload));
            //Encoding.UTF8.GetString(msg.Payload))
        }

        static void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine($"Subscribe");
        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e.Message));
        }

        static void client_BeatReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine($"ee{Encoding.UTF8.GetString(e.Message)}");
        }

        static void Main(string[] args)
        {
            //MqttClient client = new MqttClient(IPAddress.Parse("192.168.10.53"));
            //MqttClient client = new MqttClient(IPAddress.Parse("192.168.1.136"));

            MqttClient client = null;

            //client.MqttMsgPublished += client_MqttMsgPublished;

            client = new MqttClient("raspberrypi", 1883, false, null, null, MqttSslProtocols.None);

            client.MqttMsgSubscribed += client_MqttMsgSubscribed;

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgPublishReceived += client_BeatReceived;



            client.Connect(Guid.NewGuid().ToString(), "pi", "1234");

            string[] topic = { "beat_mqtt" };

            //byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
            //client.Subscribe(topic, qosLevels);


            client.Subscribe(new string[] { "beat_mqtt" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            Console.ReadLine();

        }

        
    }

    
}
