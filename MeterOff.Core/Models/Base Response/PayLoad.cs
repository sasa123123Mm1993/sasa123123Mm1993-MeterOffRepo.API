using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public class PayLoad<TModel> where TModel : class
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public int Code { get; set; } // For custom business errors
        public string Message { get; set; }
        public TModel? Data { get; set; }

    }

    /// <summary>
    /// This Is Standard Response That Return Status , Code , Message And Paylood
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Response<T>
    {
        public Response()
        {
        }

        [Display(Description ="Please Display!")]
        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public new T  payload { get; set; }

    }


    [DataContract]
    public class  ResponseAsy<T> 
    {
        public ResponseAsy()
        {
        }

        [Display(Description = "Please Display!")]
        [DataMember]
        public string statusAsy { get; set; }

        [DataMember]
        public string codeAsy { get; set; }

        [DataMember]
        public string messageAsy { get; set; }

        [DataMember]
        public new Task<T> payloadAsy { get; set; }

    }


}
