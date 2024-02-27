﻿using Microsoft.AspNetCore.Mvc;
using StoreG.DataAccess.Repository.IRepository;
using StoreG.Utility;
using System.Security.Claims;

namespace StoreGWeb.ViewComponet
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Show shopping cart count from the logged user
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                if(HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    HttpContext.Session.SetInt32(SD.SessionCart,
                   _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).Count());

                }
                    return View(HttpContext.Session.GetInt32(SD.SessionCart));        
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}
