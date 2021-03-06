﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eat_Well.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
            _svc = new ProductsSvc();
        }

        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetProductById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetProductById(Id);
            res.Data = product;
            
            return Ok(res);
        }

        // Get Method: api/Products
        [HttpGet]
        public IActionResult GetAllProductWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            var products = _svc.GetAllProductWithPagination(page, size);
            res.Data = products;

            return Ok(res);
        }

        // Post Method: api/Products
        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductsReq req)
        {
            var res = _svc.CreateProduct(req);

            return Ok(res);
        }

        // Put Method: api/Products/5
        [HttpPut("{Id}")]
        public IActionResult UpdateProduct(int Id, [FromBody]ProductsReq req)
        {
            var res = _svc.UpdateProduct(Id, req);
            
            return Ok(res);
        }

        // Delete Method: api/Products/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            var res = new SingleRsp();
            var del = _svc.DeleteProduct(Id);
            res.Data = del;
            
            return Ok(res);
        }

        // Search Product
        [HttpGet("search")]
        public IActionResult searchProductWithPagination(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.searchProductWithPagination(key, page, size);
            return Ok(res);
        }

        private readonly ProductsSvc _svc;
    }
}