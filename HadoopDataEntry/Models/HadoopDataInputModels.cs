using Nest;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HadoopDataEntry.Models
{
    // initializes database if it does not exist of the HadoopMetaDataModels type with DBset connection
    public class HadoopMetaDataInitializer : CreateDatabaseIfNotExists<HadoopMetaDataContext>
    {
        protected override void Seed(HadoopMetaDataContext context)
        {
            context.SaveChanges();
        }
    }


    public class HadoopMetaDataContext : DbContext
    {
        /* 
        On the Context we define a property that is a DbSet for every type in our model
        DbSet allows us to query and set instances of those types in our model     
        */
        // DbSet connects to database. <> is the entity  
        // The public CellData property is returning a DbSet of <CellData>

        // If DbSet is going to make a connection it needs to know where to make
        // That connection; and connection strings go in the Web.Config file
        // When you make an instance of CellToolContext, it will look for a connection
        // string with the same "name=CellToolContext"
        public DbSet<HadoopMetaDataModels> HadoopMetaDatas { get; set; }

    }

    [ElasticType(Name = "hadoop_metadata")]
    public class HadoopMetaDataModels
    {
        // Metadata fields 
        // PAT_ENC_CSN_ID|PAT_ID|AGE|SEX|ORDER_NUMBER|PROC_CODE|PROC_NAME|ORDER_DATE|COMPONENT|RESULT|CAMPUS
        // attribute key for value; keep short

        public string Id { get; set; }

        public string ExtractName { get; set; }
        public string Description { get; set; }
        public string Requestor { get; set; }
        public string RequestorEmail { get; set; }
        public string Request { get; set; }
        public string[] DataSources { get; set; }
        public string DataExtractDetails { get; set; }

        // select box; hdfs, hbase, elastic, other
        public string ClusterStorageLocation { get; set; }

        public string ClusterStoragePath { get; set; }
        public DateTime StartDate { get; set; }

    }
}