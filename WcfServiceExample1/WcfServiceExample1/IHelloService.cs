using System.ServiceModel;

namespace WcfServiceExample1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string GetData(int value);

        // TODO: Add your service operations here
    }
}
