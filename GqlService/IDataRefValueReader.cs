namespace GqlService
{
    public interface IDataRefValueReader
    {
        public object Read(string dataRefName);
    }
}