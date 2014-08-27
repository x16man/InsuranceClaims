using System;

namespace Insurance.Data.Bases
{
    /// <summary>
    /// InsuranceClaims数据库依据配置文件以抽象工厂模式来创建数据访问层.
    /// </summary>
    public abstract class DataProvider : Shmzh.Components.SystemComponent.Provider
    {
        ///<summary>
        /// Current CustomerProvider instance.
        ///</summary>
        public virtual CustomerProvider CustomerProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current InsuranceProvider instance.
        ///</summary>
        public virtual InsuranceProvider InsuranceProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current ClaimProvider instance.
        ///</summary>
        public virtual ClaimProvider ClaimProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current ClaimDetailProvider instance.
        ///</summary>
        public virtual ClaimDetailProvider ClaimDetailProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current InsuranceTypeProvider instance.
        ///</summary>
        public virtual InsuranceTypeProvider InsuranceTypeProvider { get { throw new NotImplementedException(); } }
    }
}
