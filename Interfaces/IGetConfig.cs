using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WorkerService1.Interfaces
{
    public interface IGetConfig
    {
        ConfigSerialize Config(ILogger logger);
    }
}
