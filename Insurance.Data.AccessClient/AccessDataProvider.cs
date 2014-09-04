using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Text;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;

namespace Insurance.Data.AccessClient
{
    public sealed partial class AccessDataProvider
    {
        #region Field
        private volatile AccessCustomerProvider innerAccessCustomerProvider;
        private volatile AccessInsuranceProvider innerAccessInsuranceProvider;
        private volatile AccessInsuranceTypeProvider innerAccessInsuranceTypeProvider;
        private volatile AccessClaimProvider innerAccessClaimProvider;
        private volatile AccessClaimDetailProvider innerAccessClaimDetailProvider;
        private volatile AccessBankProvider innerAccessBankProvider;
        private volatile AccessHospitalProvider innerAccessHospitalProvider;
        private volatile AccessStaffProvider innerAccessStaffProvider;
        private volatile AccessCertTypeProvider innerAccessCertTypeProvider;
        private volatile AccessClaimTypeProvider innerAccessClaimTypeProvider;
        #endregion

        #region Property

        ///<summary>
        /// 客户对象的数据访问对象。
        ///</summary>
        /// <value></value>
        public override CustomerProvider CustomerProvider
        {
            get
            {
                if (innerAccessCustomerProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessCustomerProvider == null)
                        {
                            this.innerAccessCustomerProvider = new AccessCustomerProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerAccessCustomerProvider;
            }
        }

        ///<summary>
        /// 保险单对象的数据访问对象。
        ///</summary>
        /// <value></value>
        public override InsuranceTypeProvider InsuranceTypeProvider
        {
            get
            {
                if (innerAccessInsuranceTypeProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessInsuranceTypeProvider == null)
                        {
                            this.innerAccessInsuranceTypeProvider = new AccessInsuranceTypeProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerAccessInsuranceTypeProvider;
            }
        }

        ///<summary>
        /// 保险单对象的数据访问对象。
        ///</summary>
        /// <value></value>
        public override InsuranceProvider InsuranceProvider
        {
            get
            {
                if (innerAccessInsuranceProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessInsuranceProvider == null)
                        {
                            this.innerAccessInsuranceProvider = new AccessInsuranceProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerAccessInsuranceProvider;
            }
        }

        ///<summary>
        /// 保险理赔单对象的数据访问对象。
        ///</summary>
        /// <value></value>
        public override ClaimProvider ClaimProvider
        {
            get
            {
                if (innerAccessClaimProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessClaimProvider == null)
                        {
                            this.innerAccessClaimProvider = new AccessClaimProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerAccessClaimProvider;
            }
        }

        ///<summary>
        /// 保险理赔单对象的数据访问对象。
        ///</summary>
        /// <value></value>
        public override ClaimDetailProvider ClaimDetailProvider
        {
            get
            {
                if (innerAccessClaimDetailProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessClaimDetailProvider == null)
                        {
                            this.innerAccessClaimDetailProvider = new AccessClaimDetailProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerAccessClaimDetailProvider;
            }
        }

        public override BankProvider BankProvider
        {
            get
            {
                if (innerAccessBankProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessBankProvider == null)
                        {
                            innerAccessBankProvider = new AccessBankProvider(_connectionString,_providerInvariantName);
                        }
                    }
                }
                return innerAccessBankProvider;
            }
        }

        public override HospitalProvider HospitalProvider
        {
            get
            {
                if (innerAccessHospitalProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessHospitalProvider == null)
                        {
                            innerAccessHospitalProvider = new AccessHospitalProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerAccessHospitalProvider;
            }
        }

        public override StaffProvider StaffProvider
        {
            get
            {
                if (innerAccessStaffProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessStaffProvider == null)
                        {
                            innerAccessStaffProvider = new AccessStaffProvider(_connectionString,_providerInvariantName);
                        }
                    }
                }
                return innerAccessStaffProvider;
            }
        }

        public override CertTypeProvider CertTypeProvider
        {
            get
            {
                if (innerAccessCertTypeProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessCertTypeProvider == null)
                        {
                            innerAccessCertTypeProvider = new AccessCertTypeProvider(_connectionString,_providerInvariantName);
                        }
                    }
                }
                return innerAccessCertTypeProvider;
            }
        }
        public override ClaimTypeProvider ClaimTypeProvider
        {
            get
            {
                if (innerAccessClaimTypeProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAccessClaimTypeProvider == null)
                        {
                            innerAccessClaimTypeProvider = new AccessClaimTypeProvider(_connectionString,_providerInvariantName);
                        }
                    }
                }
                return innerAccessClaimTypeProvider;
            }
        }
        #endregion
    }
}
