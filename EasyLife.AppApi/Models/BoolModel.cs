﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.AppApi.Models
{
    public class BoolModel
    {
        public BoolModel()
        {
        }

        public BoolModel(bool success)
        {
            is_success = success;
        }

        public bool is_success { get; set; }
    }
}