using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CardReader.Model;

namespace CardReader.Service
{
    public interface IReportingService
    {
        void IdReaderReport(IdReaderData data, CultureInfo locale, bool forDesigner = false);

        Task IdReaderReportAsync(IdReaderData data, CultureInfo locale, bool forDesigner = false,
            CancellationToken cancellation = default);

        void VehicleIdReport(VehicleIdData data, CultureInfo locale, bool forDesigner = false);

        Task VehicleIdReportAsync(VehicleIdData data, CultureInfo locale, bool forDesigner = false,
            CancellationToken cancellation = default);
    }
}
