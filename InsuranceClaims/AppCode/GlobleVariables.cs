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
        private volatile static List<CustomerInfo> _customers;
        private volatile static List<InsuranceTypeInfo> _insuranceTypes;
        private volatile static List<InsuranceInfo> _insurances;
        private volatile static List<ClaimInfo> _claims;
        private volatile static List<ClaimDetailInfo> _claimDetails;
        private volatile static List<BankInfo> _banks;
        private volatile static List<HospitalInfo> _hospitals;
        private volatile static List<CertTypeInfo> _certTypes;
        private volatile static List<ClaimTypeInfo> _claimTypes; 
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
                            if (_claims != null) _claims.Sort((x, y) => x.Id.CompareTo(y.Id));
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
        public static List<BankInfo> Banks
        {
            get
            {
                if (_banks == null)
                {
                    lock (SyncRoot)
                    {
                        if (_banks == null)
                        {
                            RefreshBankList();
                        }
                    }
                }
                return _banks;
            }
        } 
        public static List<HospitalInfo> Hospitals
        {
            get
            {
                if (_hospitals == null)
                {
                    lock (SyncRoot)
                    {
                        if (_hospitals == null)
                        {
                            RefreshHospitalList();
                        }
                    }
                }
                return _hospitals;
            }
        } 

        public static List<CertTypeInfo> CertTypes
        {
            get
            {
                if (_certTypes == null)
                {
                    lock (SyncRoot)
                    {
                        if (_certTypes == null)
                        {
                            RefreshCertTypeList();
                        }
                    }
                }
                return _certTypes;
            }
        } 

        public static List<ClaimTypeInfo> ClaimTypes
        {
            get
            {
                if (_claimTypes == null)
                {
                    lock (SyncRoot)
                    {
                        if (_claimTypes == null)
                        {
                            RefreshClaimTypeList();
                        }
                    }
                }
                return _claimTypes;
            }
        } 
        #endregion

        #region Method
        /// <summary>
        /// 刷新客户集合.
        /// </summary>
        public static void RefreshCustomerList()
        {
            _customers = DataRepository.CustomerProvider.GetAll();
        }
        /// <summary>
        /// 保险单集合.
        /// </summary>
        public static void RefreshInsuranceList()
        {
            _insurances = DataRepository.InsuranceProvider.GetAll();
        }
        /// <summary>
        /// 刷新报表模板集合.
        /// </summary>
        public static void RefreshClaimList()
        {
            _claims = DataRepository.ClaimProvider.GetAll();
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
        public static void RefreshBankList()
        {
            _banks = DataRepository.BankProvider.GetAll();
        }
        public static void RefreshHospitalList()
        {
            _hospitals = DataRepository.HospitalProvider.GetAll();

        }
        public static void RefreshCertTypeList()
        {
            _certTypes = DataRepository.CertTypeProvider.GetAll();
        }

        public static void RefreshClaimTypeList()
        {
            _claimTypes = DataRepository.ClaimTypeProvider.GetAll();
        }
        #endregion

    }
}