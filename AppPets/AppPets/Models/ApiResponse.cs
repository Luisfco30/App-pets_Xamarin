﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppPets.Models
{
  public  class ApiResponse
    {
        public bool IsSucces { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}
