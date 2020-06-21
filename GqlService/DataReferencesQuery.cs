using System.Linq;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace GqlService
{
    public class DataReferencesQuery
    {
        private readonly DataRefDescription[] DataRefs =
        {
            new DataRefDescription
            {
                Name = "doors.fwd_cargo", Description = "Fwd cargo door open / closed", CanRead = true, CanWrite = true,
            },
            new DataRefDescription
            {
                Name = "control.quickstart.apu", Description = "Toggle APU quickstart", CanRead = false,
                CanWrite = true,
            },
            new DataRefDescription
            {
                Name = "doors.fwd_cargo", Description = "Forward cargo door open / close", CanRead = true,
                CanWrite = true,
            },
            new DataRefDescription
            {
                Name = "aircraft.engine1.EGT", Description = "Retrieve the Exhaust Gas Temperature value of engine 1",
                CanRead = true, CanWrite = false,
            },
            new DataRefDescription
            {
                Name = "aircraft.speed.tas", Description = "Retrieve the true airspeed of the aircraft", CanRead = true,
                CanWrite = false,
            }
        };

        [UsePaging]
        [UseFiltering]
        public IQueryable<DataRefDescription> List()
        {
            return DataRefs.AsQueryable();
        }

    }
}
