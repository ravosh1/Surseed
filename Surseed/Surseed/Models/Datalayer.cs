using System;
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

        public DataSet Inline_Process(String Query)
        {

            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Query, con);


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

        public DataSet FETCH_LOGIN_DETAILS(Property p)
        {
            try
            {
                string[] paname = { "@EmailID", "@Password" };
                string[] pvalue = { p.EmailID, p.Password };
                return Ds_Process("FETCH_LOGIN_DETAILS", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int usp_setOrganization(OrganisitaionModel.Resistraion p)
        {
            try
            {
                string[] paname = {  "@OrganizationId","@OrganizationName","@OrganizationContactNumber","@Address", "@City", "@State","@Zip","@EIN#","@TAXID","@OrganizationActive", "@OrganizationUserId", "@OrganizationUserTyepId", "@FirstName","@LastName", "@Gender","@Age","@Phone","@EmailId","@OrganizationUserActive","@Password" };
                string[] pvalue = { p.OrganizationId.ToString(), p.OrganizationName, p.OrgContactNumber, p.Address, p.City, p.State, p.Zip, p.EIN,p.TAXID,p.OrganizationActive.ToString(),p.OrganizationUserId.ToString(),p.OrganizationUserTyepId,p.FirstName,p.LastName,p.Gender,p.Age,p.Phone,p.EmailId,p.OrganizationUserActive.ToString(),p.Password };
                return Int_Process("[USR].[usp_setOrganization]", paname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public DataSet FETCH_CONDITIONAL_QUERY(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@onTable" };
                string[] pvalue = { p.Condition1, p.Condition2, p.Condition3, p.onTable };
                return Ds_Process("FETCH_CONDITIONAL_QUERY", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }




        public int INSERT_UPDATE_BRAND(Property p)
        {
            try
            {
                string[] paname = { "@id", "@Brand", "@Status" };
                string[] pvalue = { p.id, p.Brand, p.Status };
                return Int_Process("INSERT_UPDATE_BRAND", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int INSERT_UPDATE_CONTACT(Property p)
        {
            try
            {
                string[] paname = { "@id", "@Name", "@Email","@Phone","@Message","@Subject" };
                string[] pvalue = { p.id, p.FullName, p.EmailID,p.Contact,p.Message,p.Subject};
                return Int_Process("INSERT_UPDATE_CONTACT", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int INSERT_UPDATE_SIZE(Property p)
        {
            try
            {
                string[] paname = { "@id", "@Size", "@Status" };
                string[] pvalue = { p.id, p.Size, p.Status };
                return Int_Process("INSERT_UPDATE_SIZE", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int INSERT_UPDATE_CATEGORY(Property p)
        {
            try
            {
                string[] paname = { "@id", "@Category", "@Status" };
                string[] pvalue = { p.id, p.Category, p.Status };
                return Int_Process("INSERT_UPDATE_CATEGORY", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int INSERT_UPDATE_SUBCATEGORY(Property p)
        {
            try
            {
                string[] paname = { "@id", "@SubCategory", "@CID", "@Status" };
                string[] pvalue = { p.id, p.SubCategory, p.CID, p.Status };
                return Int_Process("INSERT_UPDATE_SUBCATEGORY", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int INSERT_UPDATE_PRODUCTS_DETAILS(Property p)
        {
            try
            {
                string[] paname = { "@id", "@ProductName", "@Price", "@SmallDescription", "@Description", "@Status", "@CID", "@SID", "@ImgURL", "@ThumbImgURL", "@Position", "@LightType", "@Range", "@Power", "@LightColor", "@Lumen","@Shopid" };
                string[] pvalue = { p.id, p.ProductName, p.Price, p.SmallDescription, p.Description, p.Status, p.CID, p.SID, p.ImgURL, p.ThumbImgURL, p.Position, p.LightType, p.Range, p.Power, p.LightColor, p.Lumen,p.shopname };
                return Int_Process("INSERT_UPDATE_PRODUCTS_DETAILS", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        //public DataSet FETCH_ALL_MEN_DRESSES_IN_PAGING(Property p)
        //{

        //    try
        //    {
        //        string[] paname = { "@Page" };
        //        string[] pvalue = { p.Page };
        //        return Ds_Process("FETCH_ALL_PHONESALE_IN_PAGING", paname, pvalue);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public int INSERT_UPDATE_PRODUCT_PRICE(Property p)
        {
            try
            {
                string[] paname = { "@id", "@Categoryid", "@ProductId", "@Size", "@Brand", "@Others", "@Price", "@ImgURL", "@ThumbImgURL", "@FrontDisplay" };
                string[] pvalue = { p.id, p.CID, p.ProductName, p.Size, p.Brand, p.Others, p.Price, p.ImgURL, p.ThumbImgURL, p.FrontDisplay };
                return Int_Process("INSERT_UPDATE_PRODUCT_PRICE", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public DataSet FETCH_SUB_CATEGORY_LIST_MENU()
        {
            try
            {
                return MyDs_Process("FETCH_SUB_CATEGORY_LIST_MENU");
            }
            catch
            {
                throw;
            }
        }



        ////////////////////////////////////   PAYPAL PROCESS ///////////////////////

        public DataSet FillCart(Property p)
        {
            try
            {
                string[] paname = { "@cartId" };
                string[] pvalue = { p.CartID };
                return Ds_Process("FillCart_sp", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public DataSet FETCH_CUSTOMER_LOGIN_DETAILS(Property p)
        {
            try
            {
                string[] paname = { "@EmailID", "@Password" };
                string[] pvalue = { p.EmailID, p.Password };
                return Ds_Process("FETCH_CUSTOMER_LOGIN_DETAILS", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int INSERT_UPDATE_CUSTOMER_REGISTRATION(Property p)
        {
            try
            {
                string[] paname = { "@id", "@FullName", "@EmailID", "@Password", "@PostCode", "@Phone", "@Address", "@SAddress", "@Type" };
                string[] pvalue = { p.id, p.FullName, p.EmailID, p.Password, p.City, p.Contact, p.Address, p.ShippingAddress, p.Type };
                return Int_Process("INSERT_UPDATE_CUSTOMER_REGISTRATION", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }
        public int INSERT_UPDATE_GUEST_REGISTRATION(Property p)
        {
            try
            {
                string[] paname = { "@id", "@FullName", "@EmailID", "@PostCode", "@Phone", "@SAddress", "@UserType", "@CARTID" };
                string[] pvalue = { p.id, p.FullName, p.EmailID, p.Postalcode, p.Contact, p.ShippingAddress, p.UserType, p.CartID };
                return Int_Process("INSERT_UPDATE_GUEST_REGISTRATION", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }


        public int RefreshQty(Property p)
        {
            try
            {
                string[] paname = { "@id", "@qty" };
                string[] pvalue = { p.id, p.Qty };
                return Int_Process("RefreshQty", paname, pvalue);
            }
            catch (Exception ex)
            {
                //  DataSet ds = new DataSet();
                return 0;
            }
        }

        public DataSet FEATCH_USERDETAIL_BYCARTID(Property p)
        {
            try
            {
                string[] paname = { "@Cartid" };
                string[] pvalue = { p.CartID };
                return Ds_Process("FEATCH_USERDETAIL_BYCARTID", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int DeleteFromCart(Property p)
        {
            try
            {
                string[] paname = { "@id", "@CartId" };
                string[] pvalue = { p.id, p.CartID };
                return Int_Process("DeleteFromCart", paname, pvalue);
            }
            catch (Exception ex)
            {
                //  DataSet ds = new DataSet();
                return 0;
            }
        }

        public int Updateintocart(Property p)
        {
            try
            {
                string[] paname = { "@id", "@CartId", "@Qty" };
                string[] pvalue = { p.id, p.CartID, p.Qty };
                return Int_Process("Updateintocart", paname, pvalue);
            }
            catch (Exception ex)
            {
                //  DataSet ds = new DataSet();
                return 0;
            }
        }

        public int InsertUpdateCart(Property p)
        {
            try
            {
                string[] paname = { "@id", "@Qty", "@UserId", "@Price", "@CartId", "@OrderStatus", "@PaymentStatus", "@Ppid", "@ProductName", "@ProdId" };
                string[] pvalue = { p.id, p.Qty, p.UserID, p.Price, p.CartID, p.OrderStatus, p.PaymentStatus, p.pid, p.ProductName, p.ProId };
                return Int_Process("InsertUpdateCart", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public DataSet FetchCartDetailsById(Property p)
        {
            try
            {
                string[] paname = { "@id" };
                string[] pvalue = { p.CartID };
                return Ds_Process("FetchCartDetailsById", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int PAYPAL_PAYMENT_SUCCESS(Property p)
        {
            try
            {
                string[] paname = { "@CartID", "@EmailID" };
                string[] pvalue = { p.CartID, p.EmailID };
                return Int_Process("PAYPAL_PAYMENT_SUCCESS", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public int ORDER_STATUS_CHANGE(Property p)
        {
            try
            {
                string[] paname = { "@OrderID", "@Type" };
                string[] pvalue = { p.CartID, p.TypeName };
                return Int_Process("ORDER_STATUS_CHANGE", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public DataSet FETCH_CART_INFO_ORDERLIST(Property p)
        {
            try
            {
                string[] paname = { "@from", "to", "@type" };
                string[] pvalue = { p.fromdate, p.todate, p.Type };
                return Ds_Process("FETCH_CART_INFO_ORDERLIST", paname, pvalue);
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

        public DataSet FETCH_REFINE_SEARCH_DATA(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@ProductName"};
                string[] pvalue = { p.Condition1, p.Condition2, p.Condition3, p.ProductName};
                return Ds_Process("FETCH_REFINE_SEARCH_DATA", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }

        public DataSet update_tbl_cart(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4" };
                string[] pvalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4 };
                return Ds_Process("update_tbl_cart", paname, pvalue);
            }
            catch
            {
                throw;
            }
        }


    }
}