using GenMax.Database.Constant;
using GenMax.Database.EntityModel;
using GenMax.Log;
using SqlSugar;

namespace GenMax.Database.DbContext
{
    public class ProtocolDbContext
    {
        private readonly ILog _log;

        public SqlSugarScope Db;

        public ProtocolDbContext(ILog log)
        {
            _log = log;
            Db = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = Environments.ProtocolConnectionString,
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
                AopEvents = new AopEvents()
                {
                    OnLogExecuting = (sql, p) =>
                    {
                        //_log.Debug(sql);
                    }
                }
            });


            //Db.DbMaintenance.CreateDatabase();
            //Db.CodeFirst.InitTables<ExperimentRecord, SampleBarcode, PatientInfo, Project, Reagent>();
            //Db.CodeFirst.InitTables<TargetItem, MixParameter, Step, ExtractMixParameter, Protocol>();
        }

        public SimpleClient<ExperimentRecord> ExperimentRecord => new SimpleClient<ExperimentRecord>(Db);
        public SimpleClient<SampleBarcode> SampleBarcode => new SimpleClient<SampleBarcode>(Db);
        public SimpleClient<PatientInfo> PatientInfo => new SimpleClient<PatientInfo>(Db);


        public SimpleClient<Project> Project => new SimpleClient<Project>(Db);
        public SimpleClient<Reagent> Reagent => new SimpleClient<Reagent>(Db);
        public SimpleClient<TargetItem> TargetItem => new SimpleClient<TargetItem>(Db);


        public SimpleClient<MixParameter> MixParameters => new SimpleClient<MixParameter>(Db);
        public SimpleClient<Step> Steps => new SimpleClient<Step>(Db);
        public SimpleClient<ExtractMixParameter> ExtractMixParameters => new SimpleClient<ExtractMixParameter>(Db);
        public SimpleClient<Protocol> Protocols => new SimpleClient<Protocol>(Db);


    }
}
