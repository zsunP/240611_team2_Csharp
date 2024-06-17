using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace MSSQL_Melt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MS SQL Server  server부분에 자기 서버이름적으면됨[mssql실행하면처음뜨는부분] Database부분도 자기가 쓰는 DB를미리만들어놔야함
            string connectionString = "Server=DESKTOP-MSVGK7N;Database=MeltTankDB;Integrated Security=True;";

            // MS SQL Server 데이터베이스 연결
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // CSV 파일 경로 자기가저장해둔 경로이름을 여기써넣으면됨
                string csvFilePath = "C:\\Users\\KB\\Downloads\\data\\Melt\\melting_tank.csv";

                // CSV 파일에서 데이터를 읽어와 데이터베이스에 삽입
                InsertDataFromCsv(connection, csvFilePath);

                // 연결 종료
                connection.Close();
            }
        }

        static void InsertDataFromCsv(SqlConnection connection, string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
               
                using (var transaction = connection.BeginTransaction())
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction; // 트랜잭션 설정 추가

                    // CSV 파일의 각 행을 읽어와 데이터베이스에 삽입
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        command.CommandText = "INSERT INTO Melting_Tank ( STD_DT, NUM,MELT_TEMP, MOTORSPEED, MELT_WEIGHT,INSP, TAG) " +
                            "VALUES (@Field1, @Field2, @Field3, @Field4, @Field5, @Field6, @Field7)";
                        command.Parameters.Clear();
                        command.Parameters.Add("@Field1", SqlDbType.DateTime).Value = csv.GetField<DateTime>(0);
                        command.Parameters.Add("@Field2", SqlDbType.Int).Value = csv.GetField<int>(1);
                        command.Parameters.Add("@Field3", SqlDbType.Int).Value = csv.GetField<int>(2);
                        command.Parameters.Add("@Field4", SqlDbType.Int).Value = csv.GetField<int>(3);
                        command.Parameters.Add("@Field5", SqlDbType.Int).Value = csv.GetField<int>(4);
                        command.Parameters.Add("@Field6", SqlDbType.Float).Value = csv.GetField<float>(5);
                        command.Parameters.Add("@Field7", SqlDbType.VarChar).Value = csv.GetField<string>(6);
                        command.ExecuteNonQuery();
                    }
                         

                    // 트랜잭션 커밋
                    transaction.Commit();
                }
            }
        }
    }
}
