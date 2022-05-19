using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFM.Base

{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public string extractData(String tokenNAme)
        {
            String myjasonString = File.ReadAllText("Base/testData.json");

            var jsonObject = JToken.Parse(myjasonString);
            return jsonObject.SelectToken("username,").Value<String>();

        }

    }

}

