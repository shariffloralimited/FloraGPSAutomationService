using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace FloraSoft
{
    public static class ConString
    {
        public static string StringVal()
        {
            return "server=" + ConfigurationManager.AppSettings["Server"] + ";uid=floraweb;pwd=platinumfloor967;database=RTGS";
        }
    }
    public class HUBFile
    {
        public void UpdateOuwardACKData(string FileName, string ErrCD, string ErrMsg)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GPSUpdateOutwardACKFileData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlParameter sqlParameter2 = new SqlParameter("@ErrCD", SqlDbType.VarChar, 3);
            sqlParameter2.Value = ErrCD;
            sqlCommand.Parameters.Add(sqlParameter2);
            SqlParameter sqlParameter3 = new SqlParameter("@ErrMsg", SqlDbType.VarChar, 200);
            sqlParameter3.Value = ErrMsg;
            sqlCommand.Parameters.Add(sqlParameter3);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public void InsertOutwardFileData(string FileName, string Status, string MT, string Curr, string Amount, string CrValDate, string F50ORGName, string F50ADDRESS, string CrAmount, string F5859BNFName, string F5859BNFADDRESS, string DrAccount, string F5859BNFANLPartyID, string SendersRefNo, string F57BBKANLPartyID, string Field70, string Field72, string LocalReference, string UpdateTime, string MessageID, string MOP)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GPSInsertOutwardFileData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlParameter sqlParameter2 = new SqlParameter("@Status", SqlDbType.VarChar, 48000);
            sqlParameter2.Value = Status;
            sqlCommand.Parameters.Add(sqlParameter2);
            SqlParameter sqlParameter3 = new SqlParameter("@MT", SqlDbType.VarChar, 48000);
            sqlParameter3.Value = MT;
            sqlCommand.Parameters.Add(sqlParameter3);
            SqlParameter sqlParameter4 = new SqlParameter("@Curr", SqlDbType.VarChar, 255);
            sqlParameter4.Value = Curr;
            sqlCommand.Parameters.Add(sqlParameter4);
            SqlParameter sqlParameter5 = new SqlParameter("@Amount", SqlDbType.VarChar, 255);
            sqlParameter5.Value = Amount;
            sqlCommand.Parameters.Add(sqlParameter5);
            SqlParameter sqlParameter6 = new SqlParameter("@CrValDate", SqlDbType.VarChar, 255);
            sqlParameter6.Value = CrValDate;
            sqlCommand.Parameters.Add(sqlParameter6);
            SqlParameter sqlParameter7 = new SqlParameter("@F50ORGName", SqlDbType.VarChar, 255);
            sqlParameter7.Value = F50ORGName;
            sqlCommand.Parameters.Add(sqlParameter7);
            SqlParameter sqlParameter8 = new SqlParameter("@F50ADDRESS", SqlDbType.VarChar, 255);
            sqlParameter8.Value = F50ADDRESS;
            sqlCommand.Parameters.Add(sqlParameter8);
            SqlParameter sqlParameter9 = new SqlParameter("@CrAmount", SqlDbType.VarChar, 255);
            sqlParameter9.Value = CrAmount;
            sqlCommand.Parameters.Add(sqlParameter9);
            SqlParameter sqlParameter10 = new SqlParameter("@F5859BNFName", SqlDbType.VarChar, 255);
            sqlParameter10.Value = F5859BNFName;
            sqlCommand.Parameters.Add(sqlParameter10);
            SqlParameter sqlParameter11 = new SqlParameter("@F5859BNFADDRESS", SqlDbType.VarChar, 255);
            sqlParameter11.Value = F5859BNFADDRESS;
            sqlCommand.Parameters.Add(sqlParameter11);
            SqlParameter sqlParameter12 = new SqlParameter("@DrAccount", SqlDbType.VarChar, 255);
            sqlParameter12.Value = DrAccount;
            sqlCommand.Parameters.Add(sqlParameter12);
            SqlParameter sqlParameter13 = new SqlParameter("@F5859BNFANLPartyID", SqlDbType.VarChar, 255);
            sqlParameter13.Value = F5859BNFANLPartyID;
            sqlCommand.Parameters.Add(sqlParameter13);
            SqlParameter sqlParameter14 = new SqlParameter("@SendersRefNo", SqlDbType.VarChar, 255);
            sqlParameter14.Value = SendersRefNo;
            sqlCommand.Parameters.Add(sqlParameter14);
            SqlParameter sqlParameter15 = new SqlParameter("@F57BBKANLPartyID", SqlDbType.VarChar, 255);
            sqlParameter15.Value = F57BBKANLPartyID;
            sqlCommand.Parameters.Add(sqlParameter15);
            SqlParameter sqlParameter16 = new SqlParameter("@Field70", SqlDbType.VarChar, 255);
            sqlParameter16.Value = Field70;
            sqlCommand.Parameters.Add(sqlParameter16);
            SqlParameter sqlParameter17 = new SqlParameter("@Field72", SqlDbType.VarChar, 255);
            sqlParameter17.Value = Field72;
            sqlCommand.Parameters.Add(sqlParameter17);
            SqlParameter sqlParameter18 = new SqlParameter("@LocalReference", SqlDbType.VarChar, 255);
            sqlParameter18.Value = LocalReference;
            sqlCommand.Parameters.Add(sqlParameter18);
            SqlParameter sqlParameter19 = new SqlParameter("@UpdateTime", SqlDbType.VarChar, 255);
            sqlParameter19.Value = UpdateTime;
            sqlCommand.Parameters.Add(sqlParameter19);
            SqlParameter sqlParameter20 = new SqlParameter("@MessageID", SqlDbType.VarChar, 255);
            sqlParameter20.Value = MessageID;
            sqlCommand.Parameters.Add(sqlParameter20);
            SqlParameter sqlParameter21 = new SqlParameter("@MOP", SqlDbType.VarChar, 255);
            sqlParameter21.Value = MOP;
            sqlCommand.Parameters.Add(sqlParameter21);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public void ValidataAndMove(string FileName)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GPSValidateAndMove", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public void InsertInwardACKFileData(string FileName, string ACKData)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_InsertInwardACKFileData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlParameter sqlParameter2 = new SqlParameter("@ACKData", SqlDbType.VarChar, 8000);
            sqlParameter2.Value = ACKData;
            sqlCommand.Parameters.Add(sqlParameter2);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public SqlDataReader GetSingleInwardData()
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GetSingleInwardFlatFileData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public SqlDataReader GetOutwardReconData()
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GPSGetOutwardReconData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public void UpdateStatusReconFileData(string FileName)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GPSUpdateStatusReconFileData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 80);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public SqlDataReader GetInwardReconData()
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GPSGetInwardReconData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public ACKValues GPSGetOutwardACKValues(string FileName)
        {
            ACKValues aCKValues = new ACKValues();
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_GPSGetOutwardACKFileName", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlParameter sqlParameter2 = new SqlParameter("@ACKFileName", SqlDbType.VarChar, 50);
            sqlParameter2.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter2);
            SqlParameter sqlParameter3 = new SqlParameter("@ACKData", SqlDbType.VarChar, 3);
            sqlParameter3.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter3);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            aCKValues.ACKFileName = (string)sqlParameter2.Value;
            aCKValues.ACKData = (string)sqlParameter3.Value;
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
            return aCKValues;
        }
        public void UpdateStatusOuwardACKData(string FileName, string ACKFileName)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_UpdateStatusOutwardACKFileData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlParameter sqlParameter2 = new SqlParameter("@ACKFileName", SqlDbType.VarChar, 50);
            sqlParameter2.Value = ACKFileName;
            sqlCommand.Parameters.Add(sqlParameter2);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public void UpdateStatusInwardFileData(string FileName)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("HUB_UpdateStatusInwardFileData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            sqlParameter.Value = FileName;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        /// OLD CODE START
        /*
        public string BulkExcelUpload(string fileName, string DestTableName)
        {
            string result = "";
            try
            {
                SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
                myConnection.Open();
                SqlBulkCopy myBulkCopy = new SqlBulkCopy(myConnection);
                myBulkCopy.BulkCopyTimeout = 300;
                myBulkCopy.DestinationTableName = DestTableName;

                DataTable excelDT = new DataTable();
                string excelConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
                OleDbConnection myExcelConn = new OleDbConnection(excelConnString);
                myExcelConn.Open();

                DataTable dbSchema = myExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dbSchema == null || dbSchema.Rows.Count < 1)
                {
                    throw new Exception("Error: Could not determine the name of the first worksheet.");
                }
                string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();

                OleDbCommand myCmdExcel = new OleDbCommand();
                myCmdExcel.CommandText = "SELECT * FROM [" + firstSheetName + "]";
                myCmdExcel.Connection = myExcelConn;

                OleDbDataAdapter oda = new OleDbDataAdapter();
                oda.SelectCommand = myCmdExcel;
                oda.Fill(excelDT);

                myExcelConn.Close();

                myBulkCopy.WriteToServer(excelDT);
                myConnection.Close();
            }
            catch (Exception ex)
            {
                result = result + ex.ToString();
            }
            result = result + "Uploaded";
            return result;
        }

        public void ExecuteSQL(string commandText, string databaseName)
        {
            SqlConnection connection = new SqlConnection(AppVariables.DailyConStr(databaseName));
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = commandText;

            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch 
            {
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
        public string GetFileName(string SettlementDate, bool IsDay0, string EnvelopType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetFileName", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterIsDay0 = new SqlParameter("@IsDay0", SqlDbType.Bit);
            parameterIsDay0.Value = IsDay0;
            myCommand.Parameters.Add(parameterIsDay0);

            SqlParameter parameterEnvelopType = new SqlParameter("@EnvelopType", SqlDbType.VarChar, 3);
            parameterEnvelopType.Value = EnvelopType;
            myCommand.Parameters.Add(parameterEnvelopType);

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 20);
            parameterFileName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterFileName);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string FileName = (string)parameterFileName.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return FileName;
        }
        public void SetICEExpCheckID()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_SetICEExpCheckID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public string GetCurDBName()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetCurrentDB", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCurDBName = new SqlParameter("@CurDBName", SqlDbType.VarChar, 11);
            parameterCurDBName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCurDBName);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string CurDBName = (string)parameterCurDBName.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
            return CurDBName;
        }
        public SqlDataReader GetOCEData(string SettlementDate, string CCY, string FlatFileName, bool HV, int DayType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetOCEData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            SqlParameter parameterDayType = new SqlParameter("@DayType", SqlDbType.TinyInt);
            parameterDayType.Value = DayType;
            myCommand.Parameters.Add(parameterDayType); 
            
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;

        }

        public SqlDataReader GetICEData(string SettlementDate,string CCY, string FlatFileName, bool HV, bool Regenerate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetICEData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            SqlParameter parameterRegenerate = new SqlParameter("@Regenerate", SqlDbType.Bit);
            parameterRegenerate.Value = Regenerate;
            myCommand.Parameters.Add(parameterRegenerate);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public SqlDataReader GetOREData(string SettlementDate,string CCY, string FlatFileName, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetOREData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public SqlDataReader GetIREData(string SettlementDate,string CCY, string FlatFileName, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetIREData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public SqlDataReader GetChargeData(string SettlementDate,string CCY, string FlatFileName, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetChargeData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public void InsertHubAccepReject(string FileName, string A, string B, string C, string D, 
            string E, string F, string G, string H, string I)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_InsertHUBAcceptReject", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 10);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName);

            SqlParameter parameterA = new SqlParameter("@A", SqlDbType.VarChar, 50);
            parameterA.Value = A;
            myCommand.Parameters.Add(parameterA);

            SqlParameter parameterB = new SqlParameter("@B", SqlDbType.VarChar, 50);
            parameterB.Value = B;
            myCommand.Parameters.Add(parameterB);

            SqlParameter parameterC = new SqlParameter("@C", SqlDbType.VarChar, 50);
            parameterC.Value = C;
            myCommand.Parameters.Add(parameterC);

            SqlParameter parameterD = new SqlParameter("@D", SqlDbType.VarChar, 50);
            parameterD.Value = D;
            myCommand.Parameters.Add(parameterD);

            SqlParameter parameterE = new SqlParameter("@E", SqlDbType.VarChar, 50);
            parameterE.Value = E;
            myCommand.Parameters.Add(parameterE);

            SqlParameter parameterF = new SqlParameter("@F", SqlDbType.VarChar, 50);
            parameterF.Value = F;
            myCommand.Parameters.Add(parameterF);

            SqlParameter parameterG = new SqlParameter("@G", SqlDbType.VarChar, 50);
            parameterG.Value = G;
            myCommand.Parameters.Add(parameterG);

            SqlParameter parameterH = new SqlParameter("@H", SqlDbType.VarChar, 50);
            parameterH.Value = H;
            myCommand.Parameters.Add(parameterH);

            SqlParameter parameterI = new SqlParameter("@I", SqlDbType.VarChar, 3);
            parameterI.Value = I;
            myCommand.Parameters.Add(parameterI);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public void InsertHubAccepRejectBak(string FileName, string TraceNumber, string AccountNumber, string AccountName, string CheckSLNo,
            string CheckAmount, string SPINARRATIVE, string TRNStatus, string RejectReason)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_InsertHUBAcceptReject", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 18);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName);

            SqlParameter parameterTraceNumber = new SqlParameter("@TraceNumber", SqlDbType.VarChar, 18);
            parameterTraceNumber.Value = TraceNumber;
            myCommand.Parameters.Add(parameterTraceNumber);

            SqlParameter parameterAccountNumber = new SqlParameter("@AccountNumber", SqlDbType.VarChar, 18);
            parameterAccountNumber.Value = AccountNumber;
            myCommand.Parameters.Add(parameterAccountNumber);

            SqlParameter parameterAccountName = new SqlParameter("@AccountName", SqlDbType.VarChar, 10);
            parameterAccountName.Value = AccountName;
            myCommand.Parameters.Add(parameterAccountName);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.VarChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckAmount = new SqlParameter("@CheckAmount", SqlDbType.VarChar, 27);
            parameterCheckAmount.Value = CheckAmount;
            myCommand.Parameters.Add(parameterCheckAmount);

            SqlParameter parameterSPINARRATIVE = new SqlParameter("@SPINARRATIVE", SqlDbType.VarChar, 26);
            parameterSPINARRATIVE.Value = SPINARRATIVE;
            myCommand.Parameters.Add(parameterSPINARRATIVE);

            SqlParameter parameterTRNStatus = new SqlParameter("@TRNStatus", SqlDbType.VarChar, 11);
            parameterTRNStatus.Value = TRNStatus;
            myCommand.Parameters.Add(parameterTRNStatus);

            SqlParameter parameterRejectReason = new SqlParameter("@RejectReason", SqlDbType.VarChar, 25);
            parameterRejectReason.Value = RejectReason;
            myCommand.Parameters.Add(parameterRejectReason);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        public DataTable GetPastFlatFile(string SettlementDate,  int FileType, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("HUB_GetPastFlatFile", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            //SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            //parameterCCY.Value = CCY;
            //myCommand.SelectCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterFileType = new SqlParameter("@FileType", SqlDbType.Int, 4);
            parameterFileType.Value = FileType;
            myCommand.SelectCommand.Parameters.Add(parameterFileType);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);
           
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetPastHUBFile(string SettlementDate, string FileType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("HUB_GetPastHUBFile", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterFileType = new SqlParameter("@FileType", SqlDbType.VarChar, 4);
            parameterFileType.Value = FileType;
            myCommand.SelectCommand.Parameters.Add(parameterFileType);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetFileData(string FlatFileName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("HUB_GetFileData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.SelectCommand.Parameters.Add(parameterFlatFileName);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetHUBFileData(string FlatFileName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("HUB_GetHUBFileData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.SelectCommand.Parameters.Add(parameterFlatFileName);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        */

        //public void InsertOutwardData(string FileName, string LineData)
        //{
        //    SqlConnection myConnection = new SqlConnection(ConString.StringVal());
        //    SqlCommand myCommand = new SqlCommand("HUB_InsertOutwardData", myConnection);
        //    myCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
        //    parameterFileName.Value = FileName;
        //    myCommand.Parameters.Add(parameterFileName);


        //    SqlParameter parameterLineData = new SqlParameter("@LineData", SqlDbType.VarChar, 100000);
        //    parameterLineData.Value = LineData;
        //    myCommand.Parameters.Add(parameterLineData);

        //    myConnection.Open();
        //    myCommand.ExecuteNonQuery();
        //    myConnection.Close();
        //}

        //public void InsertInwardData(string FileName, string LineData)
        //{
        //    SqlConnection myConnection = new SqlConnection(ConString.StringVal());
        //    SqlCommand myCommand = new SqlCommand("HUB_InsertInwardData", myConnection);
        //    myCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
        //    parameterFileName.Value = FileName;
        //    myCommand.Parameters.Add(parameterFileName);


        //    SqlParameter parameterLineData = new SqlParameter("@LineData", SqlDbType.VarChar, 100000);
        //    parameterLineData.Value = LineData;
        //    myCommand.Parameters.Add(parameterLineData);

        //    myConnection.Open();
        //    myCommand.ExecuteNonQuery();
        //    myConnection.Close();
        //}

        /// OLD CODE END
    }
}