using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UTL
{
    public partial class Response<T>
    {
        public Boolean blnTransactionIndicator = true;
        public EMessageType enuMessageType;
        public String strMessageResponse = "Transacción realizada correctamente";
        public String strOrigin = String.Empty;
        public T ReturnValue;
    }

    #region "Enums"
    public enum EMessageType
    {
        eNone = 0,
        eValidation = 1,
        eInformative = 2,
        eError = 3,
        eRequest = 4
    }
    #endregion
}
