using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Extension
{
    class Extension
    {
    }

    public class ProcedureParameter
    {
        public string ParameterName;
        public string ParameterValue;
        public string ParameterType;
        public string ParameterDirection;

        public ProcedureParameter() { }

        public ProcedureParameter(string paramName, string paramVal, string paramType, string paramDir)
        {
            ParameterName = paramName;
            ParameterValue = paramVal;
            ParameterType = paramType;
            ParameterDirection = paramDir;
        }
    }
}
