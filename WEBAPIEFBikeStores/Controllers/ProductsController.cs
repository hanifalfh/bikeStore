using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIEFBikeStores.Models;

namespace WEBAPIEFBikeStores.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private MyDBContext db = new MyDBContext();
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var product = db.Products.Select(p => new ProductsEntity()
                {
                    productId = p.ProductId,
                    productName = p.ProductName,
                    brandId = p.BrandId,
                    categoryId = p.CategoryId,
                    modelYear = p.ModelYear,
                    listPrice = p.ListPrice

                }).ToList();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> search(string keyword)
        {
            try
            {
                var product = db.Products.Where(p => p.ProductName.Contains(keyword)).Select(p => new ProductsEntity()
                {
                    productId = p.ProductId,
                    productName = p.ProductName,
                    brandId = p.BrandId,
                    categoryId = p.CategoryId,
                    modelYear = p.ModelYear,
                    listPrice = p.ListPrice

                }).ToList();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet("bprice/{min}/{max}")]
        public async Task<IActionResult> Bprice(decimal min, decimal max)
        {
            try
            {
                var product = db.Products.Where(p => p.ListPrice >= min && p.ListPrice <= max).Select(p => new ProductsEntity()
                {
                    productId = p.ProductId,
                    productName = p.ProductName,
                    brandId = p.BrandId,
                    categoryId = p.CategoryId,
                    modelYear = p.ModelYear,
                    listPrice = p.ListPrice

                }).ToList();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var product = db.Products.Where(p => p.ProductId == id).Select(p => new ProductsEntity()
                {
                    productId = p.ProductId,
                    productName = p.ProductName,
                    brandId = p.BrandId,
                    categoryId = p.CategoryId,
                    modelYear = p.ModelYear,
                    listPrice = p.ListPrice

                }).SingleOrDefault();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductsEntity productsEntity)
        {
            try
            {
                var product =  new Products()
                {
                    ProductId = productsEntity.productId,
                    ProductName = productsEntity.productName,
                    BrandId = productsEntity.brandId,
                    CategoryId = productsEntity.categoryId,
                    ModelYear = productsEntity.modelYear,
                    ListPrice = productsEntity.listPrice

                };
                db.Products.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProductsEntity productsEntity)
        {
            try
            {
                var product = db.Products.Find(productsEntity.productId);
                product.ProductId = productsEntity.productId;
                product.ProductName = productsEntity.productName;
                product.BrandId = productsEntity.brandId;
                product.CategoryId = productsEntity.categoryId;
                product.ModelYear = productsEntity.modelYear;
                product.ListPrice = productsEntity.listPrice;
                db.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}