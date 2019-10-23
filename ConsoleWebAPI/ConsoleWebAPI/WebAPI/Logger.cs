using ConsoleWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebAPI.WebAPI
{
    public class Logger
    {
        SqlDataAdapter adapter;
        DataSet ds;


        string sqlConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DateMatch;Integrated Security=True";
        string sqlQuery = "select * from LogRecords";

        public Logger()
        {
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                con.Open();
                adapter = new SqlDataAdapter(sqlQuery, con);
                ds = new DataSet();
                adapter.Fill(ds);
            }
        }

        public void InsertLog(Log log)
        {
            DataTable dt = ds.Tables[0];
            DataRow newRow = dt.NewRow();
            newRow["Time"] = log.Time;
            newRow["Start"] = Convert.ToDateTime(log.Start);
            newRow["End"] = Convert.ToDateTime(log.End);
            newRow["isRequest"] = log.isRequest;
            dt.Rows.Add(newRow);
        }

        public void SaveChanges()
        {
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                con.Open();
                adapter = new SqlDataAdapter(sqlQuery, con);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                Console.WriteLine(commandBuilder.GetInsertCommand().CommandText);
                adapter.Update(ds);
            }
        }

    }
}
