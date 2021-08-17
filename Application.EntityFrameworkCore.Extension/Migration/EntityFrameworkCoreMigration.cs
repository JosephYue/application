using Application.EntityFrameworkCore.Extension.Migration.Interface;
using Application.EntityFrameworkCore.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.EntityFrameworkCore.Extension.Migration
{
    public class EntityFrameworkCoreMigration : IEntityFrameworkCoreMigration
    {
        private readonly EntityFrameworkCoreDbContext _dbContext;

        public EntityFrameworkCoreMigration(EntityFrameworkCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 执行表重构
        /// </summary>
        /// <returns></returns>
        public bool Migrate()
        {
            var result = true;

            using (_dbContext)
            {
                var modelDiffer = _dbContext.Database.GetService<IMigrationsModelDiffer>();

                var upOperations = modelDiffer.GetDifferences(null, RelationalModelExtensions.GetRelationalModel(_dbContext.Model));

                Migrationing(upOperations, _dbContext);
            }

            return result;
        }


        #region Private

        /// <summary>
        /// 迁移数据库结构
        /// </summary>
        /// <param name="upOperations"></param>
        /// <param name="dbContext"></param>
        private void Migrationing(IReadOnlyList<MigrationOperation> upOperations, DbContext dbContext)
        {
            List<MigrationOperation> list = new List<MigrationOperation>();

            //执行迁移列名修改
            foreach (var upOperation in upOperations)
            {
                list.Add(upOperation);
            }

            //处理剩余迁移
            if (list.Count > 0)
            {
                //通过 IMigrationsSqlGenerator 将操作迁移操作对象生成迁移的sql脚本，并执行
                var sqlList = dbContext.Database.GetService<IMigrationsSqlGenerator>()
                    .Generate(list, dbContext.Model)
                    .Select(p => p.CommandText).ToList();

                var changeCount = ExecuteListSqlCommand(dbContext, sqlList);
            }
        }

        /// <summary>
        /// 执行多条sql
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="sqlList"></param>
        private int ExecuteListSqlCommand(DbContext dbContext, List<string> sqlList)
        {
            int retunInt = 0;
            try
            {
                using var trans = dbContext.Database.BeginTransaction();

                sqlList.ForEach(cmd => retunInt += dbContext.Database.ExecuteSqlRaw(cmd));
                dbContext.Database.CommitTransaction();
            }
            catch (Exception)
            {
                try
                {
                    dbContext.Database.RollbackTransaction();
                }
                catch (Exception)
                {

                }
            }

            return retunInt;
        }

        #endregion
    }
}
