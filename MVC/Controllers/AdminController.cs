﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MVC.Controllers;

[Authorize]
public class AdminController : Controller
{
    public IActionResult Index() => View();
}