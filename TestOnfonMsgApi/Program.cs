using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestOnfonMsgApi
{
    class Program
    {
        static void Main(string[] args)
        {
            SendTestOnfonMsgApi();
            Console.ReadLine();
        }

        public static void SendTestOnfonMsgApi()
        {
            string mimi3 = "";
            string AccessKey = "n2YrC3kniDOcXKjgEiVt0pgbqdmYWFfV";
            string ScheduleDateTime = System.DateTime.Now.AddMinutes(1).ToString("yyyy-MM-dd HH:mm");
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12;
                var client = new RestClient("https://api.onfonmedia.co.ke/v1/sms/SendBulkSMS");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("AccessKey", AccessKey);
                //request.AddParameter("application/json", "{\r\n    \"RequestId\": \"5748673947966805\",\r\n    \"MobileNumber\": \"0721554225\",\r\n    \"UserPin\": \"5555\" \r\n}", ParameterType.RequestBody);
                request.AddParameter("application/json", "{\r\n  \"SenderId\": \"22141\",\r\n " +
                    " \"IsUnicode\": false,\r\n  \"IsFlash\": false,\r\n \"ScheduleDateTime\": \"" + ScheduleDateTime + 
                    "\", \r\n  \"MessageParameters\": [{ \r\n \"Number\": \"254715179567\",\r\n " +
                    " \"Text\": \"Become today a  cashless ambassador  with team M-PAY \"}], \r\n  " +
                    "  \"ApiKey\": \"ANSnwWstJeqTpb0+7/faFTFfjH0B528NXcKu2gsLHSs=\",\r\n  " +
                    "  \"ClientId\": \"b87bedf0-30e7-49d6-aac1-79f94759b883\" }", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                mimi3 = response.Content;
                Console.WriteLine(mimi3);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
