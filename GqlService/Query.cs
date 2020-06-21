using System;

namespace GqlService
{
    public class Query
    {
        private readonly DataReferencesQuery _datas;

        public Query(DataReferencesQuery datas)
        {
            _datas = datas ?? throw new ArgumentNullException(nameof(datas));
        }

        public DataReferencesQuery DataReferences() => _datas;
    }
}
