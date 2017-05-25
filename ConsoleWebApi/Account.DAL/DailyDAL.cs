﻿using Account.Common;
using Account.Entity;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.DAL
{
    public class DailyDAL
    {
        #region Private Fields

        private readonly IDatabase _database = DatabaseFactory.CreateDatabase();

        #endregion

        #region Public Methods

        /// <summary>
        /// 获取日消费清单
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<Daily> GetDailys(DateTime start, DateTime end)
        {
            IPredicate[] predicates = new IPredicate[]
            {
                Predicates.Field<Daily>(x => x.Date, Operator.Ge, start),
                Predicates.Field<Daily>(x => x.Date, Operator.Lt, new DateTime(end.Year, end.Month, end.Day).AddDays(1))
            };
            IList<ISort> sorts = new List<ISort>()
            {
                Predicates.Sort<Daily>(x => x.Date)
            };

            return _database.GetList<Daily>(Predicates.Group(GroupOperator.And, predicates), sorts);
        }
 
        /// <summary>
        /// 获取日消费清单
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<Daily> GetDailys(DateTime start, DateTime end, int pageIndex, int pageSize, ref int count)
        {
            IPredicate[] predicates = new IPredicate[]
            {
                Predicates.Field<Daily>(x => x.Date, Operator.Ge, start),
                Predicates.Field<Daily>(x => x.Date, Operator.Lt, new DateTime(end.Year, end.Month, end.Day).AddDays(1))
            };
            IList<ISort> sorts = new List<ISort>()
            {
                Predicates.Sort<Daily>(x => x.Date),
                Predicates.Sort<Daily>(x => x.Cost)
            };

            count = _database.Count<Daily>(Predicates.Group(GroupOperator.And, predicates));
            return _database.GetPage<Daily>(Predicates.Group(GroupOperator.And, predicates), sorts, pageIndex - 1, pageSize);
        }

        #endregion
    }
}
