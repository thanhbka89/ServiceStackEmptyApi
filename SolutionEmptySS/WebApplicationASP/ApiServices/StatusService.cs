using ServiceStack;
using WebApplicationASP.Status;

namespace WebApplicationASP.ApiServices
{
    public class StatusService : Service
    {
        public object Any(StatusRequest req)
        {  
            //var date = req.DateStatus.Date;
            //var mesureddata = (MeasuredData)Session[date.tostring()];
            //if (mesureddata == null)
            //{
            //    mesureddata = new MeasuredData() { Total = 500, Goal = 0 };
            //}
            var message = this.GetSession().DisplayName;
            return new StatusResponse() { Total = 200, Goal = 500, Message = message };
        }
    }

    public class MeasuredData
    {
        public int Total { get; set; }
        public int Goal { get; set; }
    }

}