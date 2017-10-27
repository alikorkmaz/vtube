using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using VTube.Controllers;
using VTube.Core.Models;

namespace VTube.Core.ViewModels
{
    public class VideoFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64), MinLength(5)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        public string Path { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<VideosController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<VideosController, ActionResult>> create =
                    (c => c.Add(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

    }
}