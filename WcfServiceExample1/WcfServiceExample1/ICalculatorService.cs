using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceExample1
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Add(int value1, int value2);
        [OperationContract]
        int Sub(int value1, int value2);
    }
}
