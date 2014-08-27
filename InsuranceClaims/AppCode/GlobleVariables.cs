using System.Collections.Generic;
using Insurance.Data.Model;
using Insurance.Data;

namespace InsuranceClaims
{
    /// <summary>
    /// 提供可以全局访问的数据对象.
    /// </summary>
    public sealed class GlobleVariables
    {
        #region Field
        private static readonly object SyncRoot = new object();
        private static List<CustomerInfo> _customers = null;
        private static List<InsuranceTypeInfo> _insuranceTypes = null;
        private static List<InsuranceInfo> _insurances = null;
        private static List<ClaimInfo> _claims = null;
        private static List<ClaimDetailInfo> _claimDetails = null;

        #endregion

        #region Property
        /// <summary>
        /// 客户集合.
        /// </summary>
        public static List<CustomerInfo> Customers
        {
            get
            {
                if(_customers == null)
                {
                    lock(SyncRoot)
                    {
                        if(_customers == null)
                        {
                            RefreshCustomerList();
                        }
                    }
                }
                return _customers;
            }
        }
        public static List<InsuranceTypeInfo> InsuranceTypes
        {
            get
            {
                if(_insuranceTypes == null)
                {
                    lock (SyncRoot)
                    {
                        if(_insuranceTypes == null)
                        {
                            RefreshResuranceTypeList();
                        }
                    }
                }
                return _insuranceTypes;
            }
        }
        /// <summary>
        /// 保险单集合.
        /// </summary>
        public static List<InsuranceInfo> Insurances
        {
            get
            {
                if(_insurances == null)
                {
                    lock(SyncRoot)
                    {
                        if (_insurances == null)
                        {
                            RefreshInsuranceList();
                        }
                    }
                }
                return _insurances;
            }
        }
        /// <summary>
        /// 保险理赔单集合.
        /// </summary>
        public static List<ClaimInfo> Claims
        {
            get
            {
                if(_claims == null)
                {
                    lock(SyncRoot)
                    {
                        if (_claims == null)
                        {
                            RefreshClaimList();
                            _claims.Sort((x, y) => x.Id.CompareTo(y.Id));
                        }
                    }
                }
                return _claims;
            }
        }
        /// <summary>
        /// 保险理赔单明细记录集合。
        /// </summary>
        public static List<ClaimDetailInfo> ClaimDetails
        {
            get
            {
                if (_claimDetails == null)
                {
                    lock (SyncRoot)
                    {
                        if (_claimDetails == null)
                        {
                            RefreshClaimDetailList();
                            _claimDetails.Sort((x, y) => x.SequenceNo.CompareTo(y.SequenceNo));
                        }
                    }
                }
                return _claimDetails;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 刷新客户集合.
        /// </summary>
        public static void RefreshCustomerList()
        {
            _customers = DataRepository.CustomerProvider.GetAll() as List<CustomerInfo>;
        }
        /// <summary>
        /// 保险单集合.
        /// </summary>
        public static void RefreshInsuranceList()
        {
            _insurances = DataRepository.InsuranceProvider.GetAll() as List<InsuranceInfo>;
        }
        /// <summary>
        /// 刷新报表模板集合.
        /// </summary>
        public static void RefreshClaimList()
        {
            _claims = DataRepository.ClaimProvider.GetAll() as List<ClaimInfo>;
        }
        /// <summary>
        /// 刷新保险理赔单明细记录集合。
        /// </summary>
        public static void RefreshClaimDetailList()
        {
            _claimDetails = DataRepository.ClaimDetailProvider.GetAll();
        }

        public static void RefreshResuranceTypeList()
        {
            _insuranceTypes = DataRepository.InsuranceTypeProvider.GetAll();
        }
        #endregion

    }
}