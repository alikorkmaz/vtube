using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using VTube.Core;
using VTube.Core.Models;
using VTube.Core.ViewModels;

namespace VTube.Controllers
{
    public class VideosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Single(int id)
        {
            var video = _unitOfWork.Videos.Get(id);
            return View(video);
        }

        [Authorize]
        public ActionResult Add()
        {
            var viewModel = new VideoFormViewModel()
            {
                Heading = "Add a Video"
            };
            return View("VideoForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            var video = _unitOfWork.Videos.Get(id);

            if (video == null)
                return HttpNotFound();

            if (video.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new VideoFormViewModel()
            {
                Heading = "Edit Video",
                Id = video.Id,
                Description = video.Description,
                Path = video.Path,
                Title = video.Title
            };

            return View("VideoForm", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(VideoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("VideoForm", viewModel);

            var video = new Video()
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                UserId = User.Identity.GetUserId(),
                CreatedDateTime = DateTime.Now,
                Path = viewModel.Path,
                Title = viewModel.Title,
            };

            _unitOfWork.Videos.Add(video);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(VideoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("VideoForm", viewModel);

            var video = _unitOfWork.Videos.Get(viewModel.Id);


            if (video == null)
                return HttpNotFound();

            if (video.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            video.Description = viewModel.Description;
            video.Path = viewModel.Path;
            video.Title = viewModel.Title;
            video.UpdatedDateTime = DateTime.Now;

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }


    }
}