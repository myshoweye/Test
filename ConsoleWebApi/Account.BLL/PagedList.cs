using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.BLL
{
    /// <summary>
    /// 分页集合
    /// </summary>
    /// <typeparam name="T">对象</typeparam>
    public class PagedList
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 返回记录的总数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 列表集合
        /// </summary>
        public IList list { get; set; }
    }
}
