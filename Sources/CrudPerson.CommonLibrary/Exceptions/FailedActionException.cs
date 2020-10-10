using CrudPerson.CommonLibrary.Resources;
using System;
using System.Runtime.Serialization;

namespace CrudPerson.CommonLibrary.Exceptions
{
    [Serializable]
    public class FailedActionException : Exception
    {
        #region Constructors
        public FailedActionException()
        {
        }

        public FailedActionException(string message) : base(message)
        {
        }

        public FailedActionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailedActionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FailedActionException(string actionName, string message) : base(GetMessage(actionName, message))
        {
            this.ActionName = actionName;
        }

        public FailedActionException(string actionName, string contextData, string message) : base(GetMessage(actionName, contextData, message))
        {
            this.ActionName = actionName;
            this.ContextData = contextData;
        }
        #endregion

        #region Public properties
        public string ActionName { get; set; }

        public string ContextData { get; set; }
        #endregion

        #region Private Static Methods
        private static string GetMessage(string actionName, string message)
        {
            // TODO : fournir un IFormatProvider qui s'appuie sur la culture courante pour faire la mise en forme
            string formatedMessage = string.Format(ExceptionResources.FailedActionException_FailedActionMessageFormat, actionName, message);
            return formatedMessage;
        }
        private static string GetMessage(string actionName, string contextData, string message)
        {
            // TODO : fournir un IFormatProvider qui s'appuie sur la culture courante pour faire la mise en forme
            string formatedMessage = string.Format(ExceptionResources.FailedActionException_FailedActionWithContentDataMessageFormat, actionName, message, contextData);
            return formatedMessage;
        }
        #endregion
    }

}
