using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CustomerForm.Models;

namespace CustomerForm.Controllers
{
    public class CustomerController : ApiController
    {
        public HttpResponseMessage Get()
        {

            string query = @"select *from CUSTOMERS";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Customers cust)
        {
            try
            {
                string query = @"insert into CUSTOMERS values (
            '" + cust.Full_Name + @"'
            ,'" + cust.Company + @"'
            ,'" + cust.Country + @"'
            ,'" + cust.Email + @"'
                )";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Add!";
            }
        }
        public string Put(Customers cust)
        {
            try
            {
                string query = @"update CUSTOMERS set 
                Full_Name='" + cust.Full_Name + @"'
                ,Company='" + cust.Company + @"'
                ,Country='" + cust.Country + @"'
                ,Email='" + cust.Email + @"'
                where rollno=" + cust.rollno + @"
                ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Update!";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from CUSTOMERS where rollno=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }
        [Route("api/Customer/GetByID/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetByID(int Id)
        {

            string query = @"select *from CUSTOMERS where rollno=" + Id + @"";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("api/Customer/GetSearchList")]
        [HttpGet]
        public HttpResponseMessage GetSearchList(string srch)
        {
            string query = @"select *from CUSTOMERS where Full_Name like " + srch + @" or Company like " + srch + @"";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
