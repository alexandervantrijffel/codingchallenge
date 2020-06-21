using System;

namespace GqlService
{
    public class DummyDataRefProvider : IDataRefValueReader
    {
        public object Read(string dataRefName)
        {
            // just a dummy value to keep this simple
            var r  = new Random((int)DateTime.UtcNow.Ticks);
            return r.Next().ToString();
        }
    }
}