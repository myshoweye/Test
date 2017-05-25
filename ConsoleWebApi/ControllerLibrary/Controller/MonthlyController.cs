using Account.BLL;
using Account.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ControllerLibrary
{
    [RoutePrefix("api/Monthly")]
    public class MonthlyController : ApiController
    {
        #region Private Fields

        private readonly MonthlyBLL _bll = new MonthlyBLL();

        #endregion

        #region Public Methods

        [Route("")]
        public IEnumerable<Monthly> GetMonthlys(string start, string end)
        {
            return _bll.GetMonthlys(start, end);
        }

        [Route("paged")]
        public dynamic GetMonthlys(string start, string end, int pageIndex, int pageSize)
        {
            return _bll.GetMonthlys(start, end, pageIndex, pageSize);
        }

        #endregion
    }
}
