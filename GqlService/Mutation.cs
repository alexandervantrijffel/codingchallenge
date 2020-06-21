using System.Threading.Tasks;

namespace GqlService
{
    public class Mutation
    {
        private DataReferenceMutation _references;

        public Mutation(DataReferenceMutation references)
        {
            _references = references;
        }

        public DataReferenceMutation References()
        {
            return _references;
        }

        public class DataReferenceMutation
        {
            public class WriteResult
            {
                public bool Ok { get; set; }
            }

            public async Task<bool> Write(string name, object value)
            {
                return true;
            }
        }
    }
}