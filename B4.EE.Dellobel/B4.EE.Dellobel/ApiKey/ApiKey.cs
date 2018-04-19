using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.DellobelI.ApiKey
{
    public class ApiKey
    {
        private string key = "SendGridKey";
        public string Key { get; set; }

        public ApiKey()
        {
            Key = key;
        }
    }
}
