using City_Mvc_Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace City_Mvc_Web_Api.Controllers.api
{

    
    public class ResidentsController : ApiController
    {

        static string connectionString = @"Data Source=LAPTOP-A88V89UT;Initial Catalog=CityDB;Integrated Security=True;Pooling=False";

        CityDbContextDataContext DataContext = new CityDbContextDataContext(connectionString);

        // GET: api/Residents
        public IHttpActionResult Get()
        {
            try
            {
                List<Resident> Residents = DataContext.Residents.ToList();
                return Ok(new { Residents });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        // GET: api/Residents/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Resident resident = DataContext.Residents.First((residentItem) => residentItem.Id == id);
                return Ok(new { resident });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Residents
        public IHttpActionResult Post([FromBody] Resident resident)
        {

            try
            {
                DataContext.Residents.InsertOnSubmit(resident);
                DataContext.SubmitChanges();
                return Ok("success");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT: api/Residents/5
        public IHttpActionResult Put(int id, [FromBody] Resident resident)
        {

            try
            {
                Resident employeeToUpdate = DataContext.Residents.Single(residentItem => residentItem.Id == id);
                employeeToUpdate = resident;
                DataContext.SubmitChanges();
                return Ok("success");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Residents/5
        public IHttpActionResult Delete(int id, Resident resident)
        {
            try
            {
                Resident employee = DataContext.Residents.First(residentItem => residentItem.Id == id);
                DataContext.Residents.DeleteOnSubmit(resident);
                DataContext.SubmitChanges();
                return Ok("success");
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
