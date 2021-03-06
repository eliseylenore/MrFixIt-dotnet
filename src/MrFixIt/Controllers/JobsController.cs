﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Claim(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult SubmitClaim(int JobId)
        {
            //action starts the process of editing the job status, but needs to actually change pending boolean to true based on AJAX
            Job thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == JobId);
            thisJob.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            thisJob.Pending = true;
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkActive(int id)
        {
            Job thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            thisJob.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            var jobList = db.Jobs.Where(jobs => jobs.Worker == thisJob.Worker);
            foreach (var job in jobList)
            {
                if(job == thisJob)
                {
                    job.IsActive = true;
                }
                else
                {
                    job.IsActive = false;
                }
            }
            
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            Job thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            thisJob.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            var jobList = db.Jobs.Where(jobs => jobs.Worker == thisJob.Worker);
            thisJob.Completed = true;      

            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
