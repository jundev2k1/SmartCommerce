// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public class RepositoryBase
    {
        protected DBContext _dbContext;
        public RepositoryBase(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Begin transaction
        /// </summary>
        /// <returns>Status callback</returns>
        public bool BeginTransaction(Action Invoke)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                Invoke();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
