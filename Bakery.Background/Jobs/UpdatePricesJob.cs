using Bakery.Background.Services;
using Quartz;
using System.Threading.Tasks;

namespace Bakery.Background.Jobs
{
    public class UpdatePricesJob: IJob
    {
        private readonly IUpdatePricesService _service;
        public UpdatePricesJob(IUpdatePricesService service)
        {
            _service = service;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await _service.Synchronize();
        }
    }
}
