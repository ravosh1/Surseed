﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Surseed.Models
{
    public class Datalayer
    {
        public static byte[] pImage;

        public int Int_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            int a = 0;
            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametername.Length; i++)
            {
                if (parametername[i] == "@img")
                {
                    cmd.Parameters.AddWithValue(parametername[i], pImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
            }
            con.Open();

            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }
        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            try
            {
                Property p = new Property();
                SqlConnection con = new SqlConnection(p.Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                DataSet ds = null;
                return ds;
            }

        }
        public DataSet MyDs_Process(String Storp)
        {

            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;

        }

        //----------------------Data Access Layer Work---------------------------

       // EncryptDecrypt enc = new EncryptDecrypt();
       

        public DataSet usp_UserLogin(OrganizationModel.Login p)
        {
            try
            {
                string[] paname = { "@EmailId", "@Password" };
                string[] pvalue = { p.EmailId, p.Password };
                return Ds_Process("USR.usp_UserLogin", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }


        public int INSERT_SHOPDETAILS_DETAILS(Property p)
        {
            try
            {
                string[] paname = { "@id", "@FullName", "@EmailID", "@Contact", "@Subject", "@Message","@store","@charges","@paypalact" };
                string[] pvalue = { p.id, p.FullName, p.EmailID, p.Contact, p.Subject, p.Message,p.shopname,p.Charges,p.paypalacct };
                return Int_Process("INSERT_SHOPDETAILS_DETAILS", paname, pvalue);

            }

            catch
            {
                throw;
            }


        }
        

    }
}