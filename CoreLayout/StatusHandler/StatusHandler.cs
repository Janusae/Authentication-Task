using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayout.StatusHandlers
{
	public class StatusHandler
	{
        public int status { get; set; }
        public string Message { get; set; }
        public StatusHandler Success(string message)
        {
            return new StatusHandler()
            {
                Message = message,
                status = (int)Status.Success,
            };
        }
		public StatusHandler Faild(string message)
		{
			return new StatusHandler()
			{
				Message = message,
				status = (int)Status.Faild,
			};
		}
		public StatusHandler NotFound(string message)
		{
			return new StatusHandler()
			{
				Message = message,
				status = (int)Status.NotFound,
			};
		}
	}
    public enum Status
    {
        Success = 200 , 
        Faild = 204 , 
        NotFound = 404
    }
}
