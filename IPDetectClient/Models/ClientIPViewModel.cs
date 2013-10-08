using System;
using System.Collections.Generic;
using System.Text;

namespace IPDectect.Client.Models
{
    public class ClientIPViewModel
    {
        private ClientIPResponse _clientIPResponse;

        public ClientIPViewModel(ClientIPResponse response)
        {
            _clientIPResponse = response;
        }

        public int SeqNo
        {
            get;
            set;
        }

        public string QueryDate
        {
            get
            {
                string date = "";
                if (!String.IsNullOrEmpty(_clientIPResponse.CreatedDate))
                    date = _clientIPResponse.CreatedDate.Replace("T"," ");

                return date;
            }

        }

        public string IP
        {
            get
            {
                return _clientIPResponse.ClientIP;
            }
        }

        public string ExpectedISP
        {
            get
            {
                return String.Format("{0}{1}",_clientIPResponse.ExpectedISPProvince, _clientIPResponse.ExpectedISP);
            }
        }

        public string RealISP
        {
            get
            {
                return String.Format("{0}{1}", _clientIPResponse.RealISPProvince, _clientIPResponse.RealISP);
            }
        }

        public string Recordor
        {
            get
            {
                return _clientIPResponse.ClientRecordor;
            }
        }

        public string Address
        {
            get
            {
                return  String.Format("{0}{1}",_clientIPResponse.ClientCity,_clientIPResponse.ClientDetailAddress);
            }
        }

        public string StatusDisplay
        {
            get
            {
                return _clientIPResponse.StatusForDisplay;
            }
        }

    }
}
