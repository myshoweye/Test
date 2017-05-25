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
    [RoutePrefix("api/Yearly")]
    public class YearlyController : ApiController
    {
        #region Private Fields

        private readonly YearlyBLL _bll = new YearlyBLL();

        #endregion

        #region Public Methods

        [Route("")]
        public IEnumerable<Yearly> GetYearlys(string start, string end)
        {
            return _bll.GetYearlys(start, end);
        }

        [Route("paged"), HttpGet]
        public dynamic GetYearlys(string start, string end, int pageIndex, int pageSize)
        {
            return _bll.GetYearlys(start, end, pageIndex, pageSize);
        }

        #endregion
    }
}
