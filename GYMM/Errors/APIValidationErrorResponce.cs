﻿using Microsoft.AspNetCore.Mvc;
using GYMM.Controllers;
using System.Collections.Generic;

namespace GYMM.Errors
{
    public class APIValidationErrorResponce : APIResponce
    {
        public APIValidationErrorResponce() : base(400)
        {

        }
        public IEnumerable<string> Errors { get; set; }

    }
}
