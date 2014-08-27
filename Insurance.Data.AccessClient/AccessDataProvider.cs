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
        private AccessCustomerProvider innerAccessCustomerProvider;
        private AccessInsuranceProvider innerAccessInsuranceProvider;
        private AccessInsuranceTypeProvider innerAccessInsuranceTypeProvider;
        private AccessClaimProvider innerAccessClaimProvider;
        private AccessClaimDetailProvider innerAccessClaimDetailProvider;
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
        #endregion
    }
}
