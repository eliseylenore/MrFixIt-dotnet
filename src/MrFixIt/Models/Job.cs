using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        //pending = someone has claimed the job
        public bool Pending { get; set; }
        //one-or-zero:many relationship, Job only has one worker.
        //add active status = your job is underway(not just in the queue)

        public bool IsActive { get; set; }
        public virtual Worker Worker { get; set; }
        //method below finds a random worker by UserName, how is it related to the Job?
        public Worker FindWorker(string UserName)
        {
            Worker thisWorker = new MrFixItContext().Workers.FirstOrDefault(i => i.UserName == UserName);
            return thisWorker;
        }
    }
}
