﻿using System;
using System.Collections.Generic;
using System.Text;

namespace comercial.business.Domain.Response
{
    public class ResponseModel<T>
    {
        public ResponseModel()
        {
            message = new List<string>();
            success = true;
        }
        public T data { get; set; }
        public IList<T> list { get; set; }
        public Boolean success { get; set; }
        public List<string> message { get; set; }
    }
}
