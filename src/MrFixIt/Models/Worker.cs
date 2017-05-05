using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace MrFixIt.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        //mispelled property - fixed
        public bool Available { get; set; }
        public string UserName { get; set; }
        //this comes from Identity.User
        //one-or-zero:many relationship, one worker has many jobs
        public virtual ICollection<Job> Jobs { get; set; }
        //need a ActiveJob property, if not available
        //once the ActiveJob is maked complete, add to jobs and delete as ActiveJob
        public Worker()
        {
            //is automatically available :)
            Available = true;
        }

    }
}